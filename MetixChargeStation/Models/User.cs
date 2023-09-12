using System;
using System.Collections.Generic;

namespace MetixChargeStation.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string SurName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int CarModelsId { get; set; }

    public virtual ICollection<UserToRole> UserToRoles { get; set; } = new List<UserToRole>();

    public virtual ICollection<CarModel> Cards { get; set; } = new List<CarModel>();
}
