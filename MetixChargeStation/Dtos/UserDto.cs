namespace MetixChargeStation.Dtos
{
    //Kullanıcı bilgileri tutulur
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string SurName { get; set; } = null!;

        public string Phone { get; set; } = null!;
        
        public int CarModelsId { get; set; }
    }
}
