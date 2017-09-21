using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BiblioWebApplicationCore.Views.Home.Components
{
    public class InvokeAddItem :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response
            = await client.GetAsync("http://localhost:5000/api/Books/GetBookTypes");
            using (HttpContent content = response.Content ?? throw new ArgumentNullException("Content"))
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<IEnumerable<Models.Type>>(result);
                return View("ModalAddItem",obj);
            }
        }
    }
}
