using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Entities.DTOs.ShipmentsDTOs
{
    public class ShipmentsCreateDTO
    {
        public string LoadAddress { get; set; } = null!;
        public string DeliveryAddress { get; set; } = null!;
        public Guid CustomerId { get; set; }
        public int StatusCode { get; set; } = 10;
        public string StatusDurum { get; set; } = "Beklemede";
        public string? Description { get; set; }

    }
}
