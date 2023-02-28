using System;
using System.Collections.Generic;

namespace DBFirst.Models;

public partial class Player
{
    public int PlayerId { get; set; }

    public int TeamId { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public int? Age { get; set; }

    public decimal? Salary { get; set; }

    public virtual Team Team { get; set; } = null!;
}
