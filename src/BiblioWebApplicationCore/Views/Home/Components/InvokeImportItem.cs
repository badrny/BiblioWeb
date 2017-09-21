using BiblioWebApplicationCore.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BiblioWebApplicationCore.Views.Home.Components
{
    public class InvokeImportItem : ViewComponent

    {
        public async Task<IViewComponentResult> InvokeAsync(string nameofbook)
        {
            IList<string> imgInfo = new List<string>();
            Book book = new Book();
            HttpClient client = new HttpClient();
            HttpResponseMessage response
            = await client.GetAsync("https://www.amazon.fr/s/ref=nb_sb_noss_2?__mk_fr_FR=%C3%85M%C3%85%C5%BD%C3%95%C3%91&url=search-alias%3Dstripbooks&field-keywords=" + nameofbook);//LES+GUERRIERS+Du+SILENCE");
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result);
                var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//li[@id='result_0']");
                foreach (var item in htmlBody.Descendants("div"))
                {
                    if (item.Attributes["class"].Value.Contains("a-col-left"))
                    {
                        var htmlImg = item.Descendants("img").First();
                        book.CoverSrc = htmlImg.Attributes["src"].Value;
                    }
                    if (item.Attributes["class"].Value.Contains("a-col-right"))
                    {
                        var htmlFirstDiv = item.Descendants("div").Where(p => p.Attributes["class"].Value.Contains("a-spacing-small")).First();
                        var htmlTitle = htmlFirstDiv.Descendants("h2").First();
                        book.Title = htmlTitle.InnerText;
                        var htmlAuthor = htmlFirstDiv.Descendants("span").Where(p => p.InnerText != "");
                        foreach (var spany in htmlAuthor)
                        {
                            imgInfo.Add(spany.InnerText);
                        }
                    }
                }
                for (int i = 1; i < imgInfo.Count; i++)
                {
                    // add names of author
                    book.Author = book.Author + imgInfo[i];
                }
                book.Date = DateTime.Parse(imgInfo[0]).ToUniversalTime();
                return View("InvokeImportItem",book);
            }
        }
    }
}