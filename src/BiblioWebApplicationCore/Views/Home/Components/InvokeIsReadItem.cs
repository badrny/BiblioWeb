using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BiblioWebApplicationCore.Views.Home.Components
{
    public class InvokeIsReadItem : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int key, string isRead)
        {
           var putContent = new StringContent("{ isread :"+ isRead +"}", Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage response
            = await client.PutAsync("http://localhost:5000/api/Books/" + key, putContent);
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();
                return View("InvokeIsReadItem", result);
            }
        }
    }
}
