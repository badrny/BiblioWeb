using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BiblioWebApplicationCore.Views.Home.Components
{
    public class InvokeNoteItem : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int key, string note)
        {
            var noteJson = JsonConvert.SerializeObject(new {key = key , note = note});
            var postContent = new StringContent(noteJson, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage response
            = await client.PostAsync("http://localhost:5000/api/Books/Note", postContent);
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();
                return View("InvokeNoteItem", result);
            }
        }
    }
}
