using EntityFrameWorkCore_Project;
using EntityFrameWorkCore_Project.Datas;
using EntityFrameWorkCore_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
//Library db(EF CORE)
//Admin panel
//Lib Id daxil ederek sisteme girish edir.
//Kitablara baxa bilmeli.
//Yeni Kitab elave ede bilir.
//Sechdiyi kitabi Update edir.
//Kitabi sile bilir (eger hemin kitabi kimse oxuyursa, sile bilmez)
//CRUD operations
LibraryContext dbContextFor = new();
Servis servis = new Servis();
MenuProj menuProj = new MenuProj();

//var t = dbContextFor.Books.ToList();
//select Books.Name , DateIn from Books Join S_Cards On S_Cards.Id_Student = Books.Id Group By Books.Name, DateIn Having DateIn Is not Null
//dbContextFor.SCards.Where(s => s.DateIn != null).ToList().ForEach(f => { Console.WriteLine(f.Id); });
var book = dbContextFor.Books.Include(B => B.SCards).Where(b => b.SCards.Any(s => s.DateIn != (null))).ToList();
//var t = dbContextFor.SCards.Where(s => s.DateIn != null).ToList();
dbContextFor.SCards.Where(s => s.).All(s => s.Equals(null)).ToList().ForEach(c => Console.WriteLine($"{c.IdBook} {c.DateIn}"));
#region RemoveLastRow
//var Removed = dbContextFor.Books.Where(b => b.Id == maxId).First();
//dbContextFor.Remove(Removed); ///////////     For Remove (Empty)
//Console.WriteLine(Removed.Name);
//dbContextFor.SaveChanges();
#endregion

Console.Write("Enter Your Id_Lib : ");
int takeNumber = int.Parse(Console.ReadLine()!);
menuProj.MenuForProj(takeNumber);
servis.ReturnAllBooks();

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