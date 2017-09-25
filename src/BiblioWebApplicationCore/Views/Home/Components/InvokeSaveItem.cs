using System.Linq;
using BiblioWebApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BiblioWebApplicationCore.Views.Home.Components
{
    public class InvokeSaveItem : ViewComponent
    {
        private readonly IConfiguration _configuration;
        public InvokeSaveItem(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IViewComponentResult> InvokeAsync(string book)
        {
            //// Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>((string)book);
            var postContent = new StringContent(book,Encoding.UTF8, "application/json");
            // Get ApiUrl from appsetting.json
            string urlApi = _configuration.GetSection("UrlHostApi").GetSection("UrlApi").Value;
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.PostAsync(urlApi, postContent))        
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
