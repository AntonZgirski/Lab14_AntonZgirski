using System;
using System.Collections.Generic;

namespace DBFirst.Models;

public partial class Coach
{
    public int CoachId { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; } = new List<Team>();
}
