using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BiblioWebApplicationCore.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BiblioWebApplicationCore.Views.Home.Components
{
    public class InvokeListItem : ViewComponent
    {
        private readonly IConfiguration _configuration;
        public InvokeListItem(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IViewComponentResult InvokeNormal()
        {
            return View();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string urlApi = _configuration.GetSection("UrlHostApi").GetSection("UrlApi").Value;
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(urlApi))
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
