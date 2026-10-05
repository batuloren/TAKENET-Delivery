namespace Transport.Shared.Models.Shipments
{
    public class GetShipmentsByTrackIdResponse
    {
        public decimal? agirlik {  get; set; }

        public string? driverFullName { get; set; }

        public string? loadAddress {  get; set; }
        public string? deliveryAddress { get; set; }

        public string? statusDurum { get; set; }

        public DateTime? shipmentDate { get; set; }

    }
    
}
