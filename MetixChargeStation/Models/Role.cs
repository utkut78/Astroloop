using System;
using System.Collections.Generic;

namespace MetixChargeStation.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserToRole> UserToRoles { get; set; } = new List<UserToRole>();
}
