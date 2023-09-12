using System;
using System.Collections.Generic;

namespace MetixChargeStation.Models;

public partial class Account
{
    public int Id { get; set; }

    public int? StationId { get; set; }

    public string? TaxNumber { get; set; }

    public string? TaxOffice { get; set; }

    public string? Address { get; set; }

    public int? City { get; set; }

    public int? Town { get; set; }

    public int? Country { get; set; }

    public string? Phone { get; set; }

    public string? Mobile { get; set; }

    public string? AuthorizedPerson { get; set; }

    public bool? IsActive { get; set; }

    public int? GroupId { get; set; }

    public virtual AccountGroup? Group { get; set; }

    public virtual Station? Station { get; set; }
}
