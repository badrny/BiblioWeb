using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BiblioWebApplicationCore.Views.Home.Components
{
    public class InvokeIsReadItem : ViewComponent
    {
        private readonly IConfiguration _configuration;
        public InvokeIsReadItem(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IViewComponentResult> InvokeAsync(int key, string isRead)
        {
            var putContent = new StringContent("{ isread :"+ isRead +"}", Encoding.UTF8, "application/json");
            string urlApi = _configuration.GetSection("UrlHostApi").GetSection("UrlApi").Value;
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.PutAsync(urlApi + key, putContent))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();
                return View("InvokeIsReadItem", result);
            }
        }
    }
}
