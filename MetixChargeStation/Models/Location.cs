using System;
using System.Collections.Generic;

namespace MetixChargeStation.Models;

public partial class Location
{
    public int Id { get; set; }

    public string Latitude { get; set; } = null!;

    public string Longitude { get; set; } = null!;

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual ICollection<Station> Stations { get; set; } = new List<Station>();
}
