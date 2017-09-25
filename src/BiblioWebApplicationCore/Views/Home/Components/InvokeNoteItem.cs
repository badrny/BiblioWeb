using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BiblioWebApplicationCore.Views.Home.Components
{
    public class InvokeNoteItem : ViewComponent
    {
        private readonly IConfiguration _configuration;
        public InvokeNoteItem(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IViewComponentResult> InvokeAsync(int key, string note)
        {
            var noteJson = JsonConvert.SerializeObject(new {key = key , note = note});
            var postContent = new StringContent(noteJson, Encoding.UTF8, "application/json");
            string urlApi = _configuration.GetSection("UrlHostApi").GetSection("UrlApi").Value;
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.PostAsync(urlApi + "Note", postContent))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();
                return View("InvokeNoteItem", result);
            }
        }
    }
}
