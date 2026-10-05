using Transport.Entities.Concrete;

namespace Transport.Entities.Shipments.DTOs
{
    public class BaseResponses<T>
    {
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
        public string? Message { get; set; }
        public T? data { get; set; }
    }

    public class ShipmentsList_ADMIN_DTO : BaseResponses<ICollection<ShipmentsList_ADMIN_Item>>
    {

    };

    public class ShipmentsList_ADMIN_Item
    {
        //SHIPMENT

        public Guid id { get; set; }
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
        public string? VehicleCarModel {  get; set; }
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

    };
}