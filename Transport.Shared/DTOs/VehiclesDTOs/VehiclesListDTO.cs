using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Shared.DTOs.VehiclesDTOs
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
        public string? Message { get; set; }
        public T? data { get; set; }
    }

    public class VehiclesListDTO : BaseResponse<ICollection<VehiclesListItem>>
    {

    };

    public class VehiclesListItem
    {
        public Guid Id { get; set; }
        public string PlakaNumara { get; set; } = null!;
        public string AracModel { get; set; } = null!;
        public decimal? AracKapasite { get; set; }
        public bool? AktifMi { get; set; }
        public string? AracBoyut { get; set; }
    };
}
