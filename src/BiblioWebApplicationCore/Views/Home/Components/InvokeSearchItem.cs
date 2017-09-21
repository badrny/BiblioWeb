
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BiblioWebApplicationCore.Views.Home.Components
{
    public class InvokeSearchItem : ViewComponent

    {
        public IViewComponentResult Invoke()
        {
                return View("ModalSearchItem");            
        }
    }
}
