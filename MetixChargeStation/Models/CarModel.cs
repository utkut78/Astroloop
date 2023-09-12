using System;
using System.Collections.Generic;

namespace MetixChargeStation.Models;

public partial class CarModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Plate { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
