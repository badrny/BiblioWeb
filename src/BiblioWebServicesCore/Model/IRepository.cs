using System.Collections.Generic;

namespace BiblioWebServicesCore.Model
{
    public interface IRepository
    {
        void Add(Book item);
        IEnumerable<Book> GetAll();
        IEnumerable<BookType> GetBookTypes();
        IEnumerable<Type> GetTypes();
        Book Find(long key);
        void Remove(long[] keys);
        void Update(Book item);
        void Update(int id, bool isRead);
    }
}
