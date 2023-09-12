using System;
using System.Collections.Generic;

namespace MetixChargeStation.Models;

public partial class AccountGroup
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
