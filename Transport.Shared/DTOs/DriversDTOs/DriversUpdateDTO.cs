namespace Transport.Shared.DTOs.DriversDTOs
{
    public class DriversUpdateDTO
    {
        public Guid Id { get; set; }
        public string Ad { get; set; } = default!;
        public string Soyad { get; set; } = default!;
        public string Telefon { get; set; } = default!;
        public string Email { get; set; } = default!;
        public bool? AktifMi { get; set; }
    }
}