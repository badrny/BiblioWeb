using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BiblioWebApplicationCore.Models;
using Newtonsoft.Json;

namespace BiblioWebApplicationCore.Views.Home.Components
{
    public class InvokeListItem : ViewComponent

    {
        public IViewComponentResult InvokeNormal()
        {
            return View();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync("http://localhost:5000/api/Books"))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();
                //// var listjson = JsonConvert.SerializeObject(result);
                var obj = JsonConvert.DeserializeObject<IEnumerable<Book>>(result);
                return View("ModalListItem", obj);
            }         
        }
    }
}
