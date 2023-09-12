namespace MetixChargeStation.Dtos
{
    //İstasyondaki sensörlerin pompa bilgisi tutulur
    public class SensorDto
    {
        public int Id { get; set; }

        public string PlugName { get; set; } = null!;

        public int StationId { get; set; }

        public bool EnergyState { get; set; }

        public int SensorModel { get; set; }

        public bool? IsActive { get; set; }

        public bool Status { get; set; }
    }
}
