using EntityFrameWorkCore_Project.Datas;
//Sechdiyi kitabi Update edir.
//Kitabi sile bilir (eger hemin kitabi kimse oxuyursa, sile bilmez)
#region obfOfClass
LibraryContext dbContextFor = new();
Servis servis = new Servis();
MenuProj menuProj = new MenuProj();
#endregion obfOfClass

#region RemoveLastRow
//var Removed = dbContextFor.Books.Where(b => b.Id == maxId).First();
//dbContextFor.Remove(Removed); ///////////     For Remove (Empty)
//Console.WriteLine(Removed.Name);
//dbContextFor.SaveChanges();
#endregion

Console.WriteLine(DateTime.Now);
while (true)
{
Begin:
    Console.Write("Enter Your Id_Lib : ");
    try
    {
        int takeNumber = int.Parse(Console.ReadLine()!);
        menuProj.MenuForProj(takeNumber);
    }
    catch (Exception ex)
    {
        Console.Clear();
        Console.WriteLine("You Entered Mistake");
        goto Begin;
    }
}


#region ConsoleReadLinesForAddBook
//Console.WriteLine("Add Book : ");
//Console.Write("Name : ");
//var cR = Console.ReadLine();
//Console.Write("Comment : ");
//var cRS = Console.ReadLine();
//var cRInt = int.Parse(Console.ReadLine()!);
//var cRInt1 = int.Parse(Console.ReadLine()!);
//var cRInt2 = int.Parse(Console.ReadLine()!);
//var cRInt3 = int.Parse(Console.ReadLine()!);
//var cRInt4 = int.Parse(Console.ReadLine()!);
//var cRInt5 = int.Parse(Console.ReadLine()!);
//var cRInt6 = int.Parse(Console.ReadLine()!);
#endregion