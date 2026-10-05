using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Shared.Models.Shipments
{
    public class GetShipmentsByCustomerEmailRequest
    {
        public string CustomerEmail { get; set; } = null!;
    }
}
