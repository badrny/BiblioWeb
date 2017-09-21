using BiblioWebApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BiblioWebApplicationCore.Views.Home.Components
{
    public class InvokeSaveItem : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string book)
        {
            HttpClient client = new HttpClient();
            //// Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>((string)book);
            var postContent = new StringContent(book,Encoding.UTF8, "application/json");
            HttpResponseMessage response
            = await client.PostAsync("http://localhost:5000/api/Books", postContent);           
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();
                //// var listjson = JsonConvert.SerializeObject(result);
                var obj = JsonConvert.DeserializeObject<Book>(result);
                return View("TableDisplayItem", obj);
            }
        }
    }
}
