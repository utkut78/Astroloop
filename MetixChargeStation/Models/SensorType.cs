using System;
using System.Collections.Generic;

namespace MetixChargeStation.Models;

public partial class SensorType
{
    public int Id { get; set; }

    public string? ModelName { get; set; }

    public virtual ICollection<Sensor> Sensors { get; set; } = new List<Sensor>();
}
