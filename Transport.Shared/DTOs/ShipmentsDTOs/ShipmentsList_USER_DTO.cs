namespace Transport.Shared.Shipments.DTOs
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
        public string? Message { get; set; }
        public T? data { get; set; }
    }

    public class ShipmentsList_USER_DTO : BaseResponse<ICollection<ShipmentsList_USER_Item>>
    {

    };

    public class ShipmentsList_USER_Item
    {
        public string TrackId { get; set; } = null!;

        public string CustomerName { get; set; } = null!;
        public string DriverName { get; set; } = null!;
        public string VehicleInfo { get; set; } = null!;
        public string StatusName { get; set; } = null!;

        public decimal? Agirlik { get; set; }
        public string LoadAddress { get; set; } = null!;
        public string DeliveryAddress { get; set; } = null!;
        public DateTime? ShipmentDate { get; set; }

        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
    };
}