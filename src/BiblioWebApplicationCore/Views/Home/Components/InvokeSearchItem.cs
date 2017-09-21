using Microsoft.AspNetCore.Mvc;

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
