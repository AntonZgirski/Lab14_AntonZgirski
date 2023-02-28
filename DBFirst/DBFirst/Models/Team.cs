using System;
using System.Collections.Generic;

namespace DBFirst.Models;

public partial class Team
{
    public int TeamId { get; set; }

    public int CoachId { get; set; }

    public string Name { get; set; } = null!;

    public string Place { get; set; } = null!;

    public int? Rate { get; set; }

    public virtual Coach Coach { get; set; } = null!;

    public virtual ICollection<Player> Players { get; } = new List<Player>();
}
