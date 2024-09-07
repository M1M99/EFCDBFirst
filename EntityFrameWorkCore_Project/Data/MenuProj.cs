using EntityFrameWorkCore_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkCore_Project.Datas
{
    internal class MenuProj
    {
        Servis servis = new();
        public void MenuForProj(int id_Lib)
        {
            var db = new LibraryContext();
            Console.Clear();
            db.Libs.Where(a => a.Id == id_Lib).ToList().ForEach(a => { Console.WriteLine($"Welcome {a.FirstName}\b."); });
            var maxId = db.Books.Max(x => x.Id);

            Console.WriteLine("1. Look All Books\n2. Add Book To Library\n3. Update Book\n4. Remove Book");
            var choise = int.Parse(Console.ReadLine()!);
            switch (choise)
            {
                case 1:
                    servis.ReturnAllBooks();
                    break;
                case 2:
                    #region ConsoleReadLinesForAddBook
                    Console.WriteLine("Add Book : ");
                    Console.Write("Name : ");
                    var cR = Console.ReadLine();
                    Console.Write("Comment : ");
                    var cRS = Console.ReadLine();
                    var cRInt = int.Parse(Console.ReadLine()!);
                    var cRInt1 = int.Parse(Console.ReadLine()!);
                    var cRInt2 = int.Parse(Console.ReadLine()!);
                    var cRInt3 = int.Parse(Console.ReadLine()!);
                    var cRInt4 = int.Parse(Console.ReadLine()!);
                    var cRInt5 = int.Parse(Console.ReadLine()!);
                    var cRInt6 = int.Parse(Console.ReadLine()!);
                    #endregion
                    Book bookClass = new(maxId + 1, cR!, cRInt, cRInt1, cRInt2, cRInt3, cRInt6, cRInt4, cRS, cRInt5);
                    servis.AddBook(bookClass);
                    break;
                case 3:
                    break;
                case 4:
                    Console.Write("Enter BookId Which Will Be Delete");
                    var ints = int.Parse(Console.ReadLine());
                    servis.RemoveBook(ints);
                    break;
                default:
                    break;
            }
        }
    }
}
