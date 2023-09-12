using System;
using System.Collections.Generic;

namespace MetixChargeStation.Models;

public partial class UserToRole
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual UserRoleClaim RoleNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual UserRoleClaim UserNavigation { get; set; } = null!;
}
