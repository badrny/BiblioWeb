using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BiblioWebApplicationCore.Views.Home.Components
{
    public class InvokeDeleteItem  :ViewComponent
    {
        private readonly IConfiguration _configuration;
        public InvokeDeleteItem(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(int[] listitemskey)
        {
            string concat = "";
            foreach (var item in listitemskey)
            {
                concat = concat + "+" + item;
            }
            //call service delete with UrlApi imported from appsetting.json
            string urlApi = _configuration.GetSection("UrlHostApi").GetSection("UrlApi").Value;
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.DeleteAsync(urlApi + concat))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();
                ////var listjson = JsonConvert.SerializeObject(result);
                ////var obj = JsonConvert.DeserializeObject<IEnumerable<Models.Type>>(result);
                return View("InvokeDeleteItem", result);
            }
        }
    }
}
