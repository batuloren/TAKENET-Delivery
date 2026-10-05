using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Shared.Models.Shipments
{
    public class GetShipmentsByIdResponse
    {
        //SHIPMENT

        public decimal? Agirlik { get; set; }
        public string LoadAddress { get; set; } = null!;
        public string DeliveryAddress { get; set; } = null!;
        public DateTime? ShipmentDate { get; set; }
        public string? Description { get; set; }
        public string? FeedbackDescription { get; set; }
        public string trackId { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public bool AktifMi { get; set; }

        //CUSTOMER

        public Guid CustomerId { get; set; }
        public string? CustomerFullName { get; set; }
        public string? CustomerTelephoneNumber { get; set; }
        public string? CustomerEmailAddress { get; set; }

        //VEHICLE 

        public Guid? VehicleId { get; set; }
        public string? VehiclePlateNumber { get; set; }
        public string? VehicleCarModel { get; set; }
        public string? VehicleCarSize { get; set; }
        public decimal? VehicleCarCapacity { get; set; }

        //DRIVER

        public Guid? DriverId { get; set; }
        public string? DriverFullName { get; set; }
        public string? DriverTelephoneNumber { get; set; }
        public string? DriverEmailAddress { get; set; }

        //STATUS 

        public Guid? StatusId { get; set; }
        public int StatusCode { get; set; }
        public string? StatusDurum { get; set; }
    }
}
