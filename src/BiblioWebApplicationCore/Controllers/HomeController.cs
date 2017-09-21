using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BiblioWebApplicationCore.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace BiblioWebApplicationCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Authentication() => View();

        public IActionResult Index(string name, string email, string password, string cpassword)
        {
            if (name == null)
            {
                try
                {
                    if (HttpContext.Session.GetString("name").Equals("webatrio"))
                    {
                        return View();
                    }
                    return RedirectToAction("Authentication");
                }
                catch (Exception)
                {
                    return RedirectToAction("Authentication");
                }
            }
            if (!name.Equals("webatrio") || !email.Equals("test@webatrio.fr") || !password.Equals("rootroot") ||
                !cpassword.Equals(password)) return Ok();
            HttpContext.Session.SetString("View", "th-list");
            HttpContext.Session.SetString("name", name);
            HttpContext.Session.SetString("email", email);
            return View();
        }

        public IActionResult Create(string title, string autor, string type) => View();

        public IActionResult Contact()
        {
            ViewData["Message"] = "Me contacter";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Information";
            return View();
        }

        public IActionResult Error() => View();

        public IActionResult CallInvokeImportItem(string nameofbook)
        {
            return ViewComponent("InvokeImportItem", nameofbook.Replace(" ", "+"));
        }

        public IActionResult CallInvokeSaveItem(List<int> _booktypes, int _format, string _title, string _author, DateTime _date, string _src)
        {
            var tt = new List<BookType>();
            foreach (var item in _booktypes)
            {
                tt.Add(new BookType { TypeID = item });
            }
            var book = new Book { Title = _title, Author = _author, CoverSrc = _src, Date = _date, Format = (Book.BookFormat)_format, Types = tt };
            return ViewComponent("InvokeSaveItem", JsonConvert.SerializeObject(book));
        }

        public IActionResult ChangeViewValToTh(string displayitem)
        {
            // change value of Tempdata(life cycle ='Session') to change display item
            HttpContext.Session.SetString("View", displayitem);
            return ViewComponent("InvokeListItem");
        }

        public IActionResult CallInvokeDeleteItem(int[] itemskey) => ViewComponent("InvokeDeleteItem", itemskey);

        public IActionResult CallInvokeIsReadItem(int key, string isread)
        {
            var obj = new { Key = key, isRead = isread };
            return ViewComponent("InvokeIsReadItem", obj);
        }

        public IActionResult CallGetNote(int key) => ViewComponent("InvokeNoteItem", key);
    }
}
