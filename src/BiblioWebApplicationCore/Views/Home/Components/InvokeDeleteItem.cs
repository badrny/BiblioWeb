using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace BiblioWebApplicationCore.Views.Home.Components
{
    public class InvokeDeleteItem  :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int[] listitemskey)
        {
            string concat = "";
            foreach (var item in listitemskey)
            {
                concat = concat + "+" + item;
            }
            HttpClient client = new HttpClient();
            HttpResponseMessage response
            = await client.DeleteAsync("http://localhost:5000/api/Books/"+concat);
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();
                // //var listjson = JsonConvert.SerializeObject(result);
                ////var obj = JsonConvert.DeserializeObject<IEnumerable<Models.Type>>(result);
                return View("InvokeDeleteItem", result);
            }
        }
    }
}
