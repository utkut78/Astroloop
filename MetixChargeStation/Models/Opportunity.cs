using System;
using System.Collections.Generic;

namespace MetixChargeStation.Models;

public partial class Opportunity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Details { get; set; }

    public virtual ICollection<Station> Stations { get; set; } = new List<Station>();
}
