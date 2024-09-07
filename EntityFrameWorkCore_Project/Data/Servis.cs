using EntityFrameWorkCore_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkCore_Project.Datas
{
    internal class Servis
    {
        LibraryContext db = new LibraryContext();
        Book book = new Book();
        public void ReturnAllBooks()
        {
            db.Books.ToList().ForEach(b => { Console.WriteLine(b.Name); });
        }

        public void AddBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }
        public void UpdaterBook(Book book)
        {

        }

        public void RemoveBook(int bookId)
        {
            db.TCards.Where(tC => tC.DateIn != null).ToList().ForEach(f => { Console.WriteLine($"{f.IdBook}\n\n\n"); });
            db.SCards.Where(s => s.DateIn != null).ToList().ForEach(f => { Console.WriteLine(f.Id); });
        }
    }
}

