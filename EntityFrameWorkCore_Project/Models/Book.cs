using System;
using System.Collections.Generic;

namespace EntityFrameWorkCore_Project.Models;

public class Book
{
    public Book(int Id, string Name, int Pages, int YearPress, int IdThemes, int IdCategory, int IdAuthor, int IdPress, string? Comment, int Quantity)
    {
        this.Id = Id;
        this.Name = Name;
        this.Pages = Pages;
        this.YearPress = YearPress;
        this.IdThemes = IdThemes;
        this.IdCategory = IdCategory;
        this.IdAuthor = IdAuthor;
        this.IdPress = IdPress;
        this.Comment = Comment;
        this.Quantity = Quantity;
        //SCards = sCards;
        //TCards = tCards;
    }

    public Book() { }
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Pages { get; set; }

    public int YearPress { get; set; }

    public int IdThemes { get; set; }

    public int IdCategory { get; set; }

    public int IdAuthor { get; set; }

    public int IdPress { get; set; }

    public string? Comment { get; set; }

    public int Quantity { get; set; }

    public virtual ICollection<SCard> SCards { get; set; } = new List<SCard>();

    public virtual ICollection<TCard> TCards { get; set; } = new List<TCard>();
}
