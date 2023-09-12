using System;
using System.Collections.Generic;

namespace MetixChargeStation.Models;

public partial class Sensor
{
    public int Id { get; set; }

    public string PlugName { get; set; } = null!;

    public int StationId { get; set; }

    public bool EnergyState { get; set; }

    public int SensorModel { get; set; }

    public bool? IsActive { get; set; }

    public bool Status { get; set; }

    public virtual SensorType SensorModelNavigation { get; set; } = null!;

    public virtual Station Station { get; set; } = null!;
}
