using System;
using System.Collections.Generic;

namespace DBFirst.Models;

public partial class VlistPlayerOnTeam
{
    public string Name { get; set; } = null!;

    public string Place { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public decimal? Salary { get; set; }
}
