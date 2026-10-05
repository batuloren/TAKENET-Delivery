using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Entities.DTOs.StatusesDTOs
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
        public string? Message { get; set; }
        public T? data { get; set; }
    }

    public class StatusesListDTO : BaseResponse<ICollection<StatusesListItem>>
    {

    };

    public class StatusesListItem
    {
        public Guid Id { get; set; }
        public string? Durum { get; set; } = null!;
        public int? StatusCode { get; set; } = null!;
    };
}
