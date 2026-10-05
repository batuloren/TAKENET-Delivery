namespace Transport.Shared.DTOs
{
    public class DriversCreateDTO
    {
        public string Ad { get; set; } = null!;
        public string Soyad { get; set; } = null!;
        public string Telefon { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool AktifMi {get; set; } = true;
    };
}