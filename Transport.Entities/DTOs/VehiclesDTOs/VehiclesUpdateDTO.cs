using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Entities.DTOs.VehiclesDTOs
{
    public class VehiclesUpdateDTO
    {
        public Guid Id { get; set; }
        public string PlakaNumara { get; set; } = null!;
        public string AracModel { get; set; } = null!;
        public decimal AracKapasite { get; set; }
        public bool AktifMi { get; set; }
        public string? AracBoyut { get; set; }
    }
}
