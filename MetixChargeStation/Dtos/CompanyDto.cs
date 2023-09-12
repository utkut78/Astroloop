namespace MetixChargeStation.Dtos
{
    //İstasyonlar için Şirket bilgileri tutulur
    public class CompanyDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public int LocationId { get; set; }
    }
}
