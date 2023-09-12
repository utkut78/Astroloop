namespace MetixChargeStation.Dtos
{
    //Lokasyon bilgileri tutulur
    public class LocationDto
    {
        public int Id { get; set; }

        public string Latitude { get; set; } = null!;

        public string Longitude { get; set; } = null!;
    }
}
