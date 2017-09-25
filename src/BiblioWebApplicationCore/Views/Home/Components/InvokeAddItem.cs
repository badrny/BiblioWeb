using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BiblioWebApplicationCore.Views.Home.Components
{
    public class InvokeAddItem :ViewComponent
    {
        private readonly IConfiguration _configuration;
        public InvokeAddItem(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string urlApi = _configuration.GetSection("UrlHostApi").GetSection("UrlApi").Value;

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(urlApi + "GetBookTypes"))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<IEnumerable<Models.Type>>(result);
                return View("ModalAddItem", obj);
            }
        }
    }
}
