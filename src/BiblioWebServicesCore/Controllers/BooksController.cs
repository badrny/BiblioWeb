using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BiblioWebServicesCore.Model;

namespace BiblioWebServicesCore.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        public IRepository Books { get; set; } 

        public BooksController(IRepository books)
        {
           Books = books;
        }
        
        // GET api/books
        [HttpGet]
        public ActionResult GetAll()
        {
            List<Book> list = Books.GetAll().ToList();
            return Json(Books.GetAll().ToList());
        }

        // GET api/books/Search
        [HttpGet("{search}")]
        public IActionResult GetBook(string search, [Bind(Prefix ="query")] string chaine)
        {
            return  Json(Books.GetAll().Where(a => (a.Title).StartsWith(chaine,StringComparison.OrdinalIgnoreCase)).Select(p=>new {id = p.Key ,label = p.Title } ));
        }

        // GET api/books/GetBookType
        [HttpGet("{GetBookType}")]
        public IActionResult GetBookTypes()
        {
            return Json(Books.GetTypes());
        }

        // add book
        // POST api/books
        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            if (book==null)
            {
                BadRequest();
            }           
            Books.Add(book);
            return Ok(book);
        }

        // POST api/books/Note
        [HttpPost("{Note}")]
        public IActionResult Note([FromBody] Book book)
        {
            if (book == null)
            {
                BadRequest();
            }
            Books.Add(book);
            return Ok(book);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]bool isRead)
        {
            Books.Update(id, isRead);
            return Ok();
        }

        [HttpPut]
        public void Update([FromBody]Book book)
        {
            Books.Update(book);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public int Delete(string id)
        {           
            string[] ids = id.Split('+');
            long[] keys = new long[ids.Count() - 1];
            for (int i = 1; i < ids.Count(); i++ )
            {
                keys[i-1] = int.Parse(ids[i]);
            }
            Books.Remove(keys);
            return keys.Count();
        }
    }
}
