using Transport.Entities.Concrete;

namespace Transport.Entities.DTOs
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
        public string? Message { get; set; }
        public T? data { get; set; }
    }

    public class DriversListDTO : BaseResponse<ICollection<DriversListItem>>
    {
        
    }; 

    public class DriversListItem
    {
        public Guid Id { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? FullName { get; set; }
        public string? Telefon { get; set; }
        public string? Email { get; set; }
        public bool? AktifMi { get; set; }
    };
}