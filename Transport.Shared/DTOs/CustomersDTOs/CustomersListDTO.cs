using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Shared.DTOs.CustomersDTOs
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
        public string? Message { get; set; }
        public T? data { get; set; }
    }

    public class CustomersListDTO : BaseResponse<ICollection<CustomersListItem>>
    {

    };

    public class CustomersListItem
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? Telefon { get; set; }
        public string? Email { get; set; }
        public bool? AktifMi { get; set; }
    };
}
