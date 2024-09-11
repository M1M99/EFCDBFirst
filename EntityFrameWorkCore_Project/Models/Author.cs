using System;
using System.Collections.Generic;

namespace EntityFrameWorkCore_Project.Models;

public partial class Author
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
