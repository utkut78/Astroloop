using System;
using System.Collections.Generic;

namespace MetixChargeStation.Models;

public partial class UserRoleClaim
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<UserToRole> UserToRoleRoleNavigations { get; set; } = new List<UserToRole>();

    public virtual ICollection<UserToRole> UserToRoleUserNavigations { get; set; } = new List<UserToRole>();
}
