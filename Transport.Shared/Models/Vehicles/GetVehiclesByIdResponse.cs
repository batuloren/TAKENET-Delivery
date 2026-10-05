using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Shared.Models.Vehicles
{
    public class GetVehiclesByIdResponse
    {
        public string? PlakaNumara { get; set; }
        public string? AracModel { get; set; }
        public decimal? AracKapasite { get; set; }
        public bool? AktifMi { get; set; }
        public string? AracBoyut { get; set; }
    }
}
