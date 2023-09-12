using System;
using System.Collections.Generic;

namespace MetixChargeStation.Models;

public partial class Station
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CompanyId { get; set; }

    public bool? IsActive { get; set; }

    public int LocationId { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual Company Company { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;

    public virtual ICollection<Sensor> Sensors { get; set; } = new List<Sensor>();

    public virtual ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
}
