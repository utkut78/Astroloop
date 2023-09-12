namespace MetixChargeStation.Dtos
{
    //Her bir şirket içn istasyon bilgisi tutulur 
    public class StationDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int CompanyId { get; set; }

        public bool? IsActive { get; set; }

        public int LocationId { get; set; }
    }
}
