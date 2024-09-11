using EntityFrameWorkCore_Project.Models;
using Microsoft.EntityFrameworkCore;
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
            db.Books.ToList().ForEach(b => { Console.WriteLine($"{b.Id}. {b.Name}"); });
        }

        public void AddBook(Book book)
        {
            db.Books.Add(book);
            Console.WriteLine("Successfully Added");
            db.SaveChanges();
        }

        public void RemoveBook(int bookId)
        {
            var countOfNullDI = db.SCards.Where(tC => tC.DateIn.Equals(null) && bookId == tC.IdBook).Include(sc => sc.IdBookNavigation).ToList().Count();
            var countOfNullDIT_C = db.TCards.Where(tC => tC.DateIn.Equals(null) && bookId == tC.IdBook).Include(Tc => Tc.IdBookNavigation).ToList().Count();
            if (countOfNullDI == 0 && db.Books.Any(b => b.Id == bookId) && countOfNullDIT_C == 0) 
            {
                var bookToRemove = db.Books.FirstOrDefault(b => b.Id == bookId);

                if (bookToRemove != null)
                {
                    db.SCards.RemoveRange(db.SCards.Where(sc => sc.IdBook == bookId));
                    db.TCards.RemoveRange(db.TCards.Where(tc => tc.IdBook == bookId));

                    db.Books.Remove(bookToRemove);
                    db.SaveChanges();
                    Console.WriteLine("Deleted\nClick Enter For Continue");
                    Console.ReadKey();
                }
            }
            else if(countOfNullDI > 0 || countOfNullDIT_C > 0)
            {
                Console.WriteLine("This Book Is Reading! You Can't This Book");
            }
            else
                Console.WriteLine("False BookId");
            Console.ReadKey();
        }
    }
}

