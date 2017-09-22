using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BiblioWebServicesCore.Model
{
    public class BookRepository : IRepository
    { 
        private readonly BookContext _context;

        public BookRepository(BookContext context) => _context = context;

        public void Add(Book item)
        {
            _context.Books.Add(item);
            _context.SaveChanges();
        }

        public Book Find(long key) => _context.Books.Find(key);

        public IEnumerable<Book> GetAll()
        {
            _context.Books.Load();
            _context.Types.Load();
            _context.BookTypes.Load();

            return _context.Books; 
        }

        public IEnumerable<BookType> GetBookTypes() => _context.BookTypes;

        public IEnumerable<Type> GetTypes() => _context.Types.ToList();

        public void Remove(long[] keys)
        {
            if (keys == null) throw new ArgumentNullException(nameof(keys));
            foreach (var item in keys)
            {
                var entity = _context.Books.First(t => t.Key == item);
                _context.Books.Remove(entity);
                _context.SaveChanges();
            }
        }

        public void Update(Book item)
        {
            _context.Books.Update(item);
            _context.SaveChanges();
        }

        public void Update(int id, bool isRead)
        {
            // find the book and update it
            Book book = _context.Books.FirstOrDefault(t => t.Key == id);
            book.IsRead = !isRead;
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}
