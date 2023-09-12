namespace MetixChargeStation.Dtos
{
    //Araç bilgileri tutulur
    public class CarModelDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Plate { get; set; } = null!;
    }
}
