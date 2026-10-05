using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Entities.DTOs.ShipmentsDTOs
{
    public class ShipmentsUpdateDTO
    {
        public Guid Id { get; set; }
        public Guid DriverId { get; set; }
        public Guid VehicleId { get; set; }
        public int StatusCode { get; set; }

        public decimal Agirlik { get; set; }
        public bool AktifMi { get; set; }
        public string? FeedbackDescription { get; set; }
    }
}
