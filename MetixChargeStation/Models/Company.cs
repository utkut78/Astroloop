using System;
using System.Collections.Generic;

namespace MetixChargeStation.Models;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int LocationId { get; set; }

    public virtual Location Location { get; set; } = null!;

    public virtual ICollection<Station> Stations { get; set; } = new List<Station>();
}
