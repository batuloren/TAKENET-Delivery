using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Entities.Shipments.DTOs;

namespace Transport.Business.Models.Shipments
{
    public class GetShipmentsByCustomerEmailResponse
    {

        public List<ShipmentsList_ADMIN_Item> Shipments { get; set; } = new();
        public string? CustomerName { get; set; } = null!;
        public string? CustomerEmailAddress { get; set; }

    }
}
