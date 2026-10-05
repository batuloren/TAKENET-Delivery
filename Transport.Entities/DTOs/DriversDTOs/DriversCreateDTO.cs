namespace Transport.Entities.DTOs
{
    public record DriversCreateDTO(
        string Ad,
        string Soyad,
        string Telefon,
        string Email
    );
}