using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Shared.DTOs.ShipmentsDTOs
{
    public class ShipmentsTableAdminDTO
    {
        public Guid id { get; set; }

        public string trackId { get; set; } = null!;

        public bool AktifMi { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? CustomerFullName { get; set; }

        public string? VehiclePlateNumber { get; set; }

        public string? DriverFullName { get; set; }

        public Guid? statusId { get; set; }

        public int StatusCode { get; set; }

        public string? StatusDurum { get; set; }

        public decimal? Agirlik { get; set; }

        public string LoadAddress { get; set; } = null!;

        public string DeliveryAddress { get; set; } = null!;

        public DateTime? ShipmentDate { get; set; }

        public string? Description { get; set; }

        public string? FeedbackDescription { get; set; }

    }
}
