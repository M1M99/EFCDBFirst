using EntityFrameWorkCore_Project.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Drawing;
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

            string? cRForUpdate;
            string? cRSFU;
            int cRIntFU;
            int cRInt1FU;
            int cRInt2FU;
            int cRInt3FU;
            int cRInt4FU;
            int cRInt5FU;
            int cRInt6FU;

            string? cR;
            string? cRS;
            int cRInt;
            int cRInt1;
            int cRInt2;
            int cRInt3;
            int cRInt4;
            int cRInt5;
            int cRInt6;

            var db = new LibraryContext();

            if ((db.Libs.Any(L => L.Id == id_Lib)))
            {
                Console.Clear();
                db.Libs.Where(a => a.Id == id_Lib).ToList().ForEach(a => { Console.WriteLine($"Welcome {a.FirstName}\b."); });
                var maxId = db.Books.Max(x => x.Id);
            returnB:
                Console.Write("1. Look All Books\n2. Add Book To Library\n3. Update Book\n4. Remove Book\nMake Choise : ");
                try
                {
                    var choise = int.Parse(Console.ReadLine()!);
                    switch (choise)
                    {
                        case 1:
                            Console.Clear();
                            servis.ReturnAllBooks();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Click ENTER For Continue!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            Console.Clear();
                            goto returnB;
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("\t\t\tAdd Book");
                        ForNameReturn:
                            try
                            {
                                Console.Write("Name : ");
                                cR = Console.ReadLine();
                                if (cR.IsNullOrEmpty()) { throw new Exception(); };
                            }
                            catch (Exception ex) { Console.Clear(); goto ForNameReturn; }
                        forCommentReturn:
                            try
                            {
                                Console.Clear();
                                Console.Write("Comment : ");
                                cRS = Console.ReadLine();
                                if (cRS.IsNullOrEmpty()) { throw new Exception(); };
                            }
                            catch (Exception ex)
                            {
                                Console.Clear();
                                goto forCommentReturn;
                            }
                        forPagesRet:
                            try
                            {
                                Console.Clear();
                                Console.Write("Pages : ");
                                cRInt = int.Parse(Console.ReadLine()!);
                            }
                            catch (Exception)
                            {
                                goto forPagesRet;
                            }
                        forYearPress:
                            try
                            {
                                Console.Clear();
                                Console.Write("YearPress : ");
                                cRInt1 = int.Parse(Console.ReadLine()!);
                            }
                            catch (Exception ex)
                            {
                                goto forYearPress;
                            }
                        Themesid:
                            try
                            {
                                Console.Clear();
                                Console.Write("Themes Id : ");
                                cRInt2 = int.Parse(Console.ReadLine()!);
                                if (!db.Themes.Any(t => t.Id == cRInt2))
                                {
                                    throw new Exception("Theme Id False");
                                }

                            }
                            catch (Exception)
                            {
                                goto Themesid;
                            }
                        CategoryId:
                            try
                            {
                                Console.Clear();
                                Console.Write("Category Id : ");
                                cRInt3 = int.Parse(Console.ReadLine()!);
                                if (!db.Categories.Any(t => t.Id == cRInt3))
                                {
                                    throw new Exception("Category Id False");
                                }
                            }
                            catch (Exception)
                            {
                                goto CategoryId;
                            }
                        AuthorId:
                            try
                            {
                                Console.Clear();
                                Console.Write("Author Id : ");
                                cRInt4 = int.Parse(Console.ReadLine()!);
                                if (!db.Authors.Any(t => t.Id == cRInt4))
                                {
                                    throw new Exception("Author Id False");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex.Message);
                                goto AuthorId;
                            }
                        PressId:
                            try
                            {
                                Console.Clear();
                                Console.Write("Press Id : ");
                                cRInt5 = int.Parse(Console.ReadLine()!);
                                if (!db.Presses.Any(t => t.Id == cRInt5))
                                {
                                    throw new Exception("Press Id False");
                                }
                            }
                            catch (Exception)
                            {
                                goto PressId;
                            }
                        Quatity:
                            try
                            {
                                Console.Clear();
                                Console.Write("Quantity : ");
                                cRInt6 = int.Parse(Console.ReadLine()!);
                            }
                            catch (Exception)
                            {
                                goto Quatity;
                            }
                            Book bookClass = new(maxId + 1, cR!, cRInt, cRInt1, cRInt2, cRInt3, cRInt6, cRInt4, cRS, cRInt5);
                            servis.AddBook(bookClass);
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("\t\t\tUpdate Book");
                            servis.ReturnAllBooks();
                        f:
                            Console.Write("Enter BookId For Update :");
                            try
                            {
                                int bookId = int.Parse(Console.ReadLine());
                                if (db.Books.Any(b => b.Id == bookId))
                                {
                                begin1:
                                    try
                                    {
                                        if (db.Books.Any(f => f.Id == bookId))
                                        {
                                        ForNameReturnForUpdateFU:
                                            try
                                            {
                                                Console.Clear();
                                                Console.WriteLine("\t\t\tUpdate Book");
                                                Console.Write("Name : ");
                                                cRForUpdate = Console.ReadLine();
                                                if (cRForUpdate.IsNullOrEmpty()) { throw new Exception(); };
                                            }
                                            catch (Exception ex) { Console.Clear(); goto ForNameReturnForUpdateFU; }
                                        forCommentReturnForUpdate:
                                            try
                                            {
                                                Console.Clear();
                                                Console.Write("Comment : ");
                                                cRSFU = Console.ReadLine();
                                                if (cRSFU.IsNullOrEmpty()) { throw new Exception(); };
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.Clear();
                                                goto forCommentReturnForUpdate;
                                            }
                                        forPagesRetFU:
                                            try
                                            {
                                                Console.Clear();
                                                Console.Write("Pages : ");
                                                cRIntFU = int.Parse(Console.ReadLine()!);
                                            }
                                            catch (Exception)
                                            {
                                                goto forPagesRetFU;
                                            }
                                        forYearPressFU:
                                            try
                                            {
                                                Console.Clear();
                                                Console.Write("YearPress : ");
                                                cRInt1FU = int.Parse(Console.ReadLine()!);
                                            }
                                            catch (Exception ex)
                                            {
                                                goto forYearPressFU;
                                            }
                                        ThemesidFU:
                                            try
                                            {
                                                Console.Clear();
                                                Console.Write("Themes Id : ");
                                                cRInt2FU = int.Parse(Console.ReadLine()!);
                                                if (!db.Themes.Any(t => t.Id == cRInt2FU))
                                                {
                                                    throw new Exception("Theme Id False");
                                                }

                                            }
                                            catch (Exception)
                                            {
                                                goto ThemesidFU;
                                            }
                                        CategoryIdFU:
                                            try
                                            {
                                                Console.Clear();
                                                Console.Write("Category Id : ");
                                                cRInt3FU = int.Parse(Console.ReadLine()!);
                                                if (!db.Categories.Any(t => t.Id == cRInt3FU))
                                                {
                                                    throw new Exception("Category Id False");
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                goto CategoryIdFU;
                                            }
                                        AuthorIdFU:
                                            try
                                            {
                                                Console.Clear();
                                                Console.Write("Author Id : ");
                                                cRInt4FU = int.Parse(Console.ReadLine()!);
                                                if (!db.Authors.Any(t => t.Id == cRInt4FU))
                                                {
                                                    throw new Exception("Author Id False");
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.Clear();
                                                Console.WriteLine(ex.Message);
                                                goto AuthorIdFU;
                                            }
                                        PressIdFU:
                                            try
                                            {
                                                Console.Clear();
                                                Console.Write("Press Id : ");
                                                cRInt5FU = int.Parse(Console.ReadLine()!);
                                                if (!db.Presses.Any(t => t.Id == cRInt5FU))
                                                {
                                                    throw new Exception("Press Id False");
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                goto PressIdFU;
                                            }
                                        QuatityFU:
                                            try
                                            {
                                                Console.Clear();
                                                Console.Write("Quantity : ");
                                                cRInt6FU = int.Parse(Console.ReadLine()!);
                                            }
                                            catch (Exception)
                                            {
                                                goto QuatityFU;
                                            }
                                            Book book = new Book(bookId, cRForUpdate, cRIntFU, cRInt1FU, cRInt2FU, cRInt3FU, cRInt4FU, cRInt5FU, cRSFU, cRInt6FU);
                                            var t = db.Books.First(f => f.Id == book.Id);
                                            t.Name = cRForUpdate;
                                            t.Comment = cRSFU;
                                            t.Pages = cRIntFU;
                                            t.YearPress = cRInt1FU;
                                            t.IdAuthor = cRInt4FU;
                                            t.IdPress = cRInt5FU;
                                            t.Quantity = cRInt6FU;
                                            t.IdCategory = cRInt3FU;
                                            t.IdThemes = cRInt2FU;
                                            db.Books.Update(t);
                                            db.SaveChanges();
                                            Console.WriteLine("Updated");
                                        }
                                    }


                                    catch (Exception EX)
                                    {
                                        Console.WriteLine("Have Problem Try Again!");
                                        goto begin1;
                                    }
                                }
                                else { Console.Clear(); servis.ReturnAllBooks(); Console.WriteLine("Try Again You Make False Choise"); goto f; }
                            }
                            catch(Exception ex) {
                                Console.Clear();
                                servis.ReturnAllBooks();
                                goto f;
                            }
                            break;
                        case 4:
                            Console.Clear();
                            Console.Write("Enter BookId Which Will Be Delete : ");
                            var ints = int.Parse(Console.ReadLine());
                            servis.RemoveBook(ints);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("False Choise!");
                            goto returnB;
                    }
                }
                catch (Exception ex)
                {
                    goto returnB;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("False Libs_Id");
            }
        }
    }
}
