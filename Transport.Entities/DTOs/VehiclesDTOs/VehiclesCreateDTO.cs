using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Entities.DTOs.VehiclesDTOs
{
    public class VehiclesCreateDTO
    {
        [Required]
        public string PlakaNumara { get; set; } = null!;

        [Required]
        public string AracModel { get; set; } = null!;

        [Required]
        public decimal AracKapasite { get; set; }

        [Required]
        public bool AktifMi { get; set; }

        [Required]
        public string AracBoyut { get; set; } = null!;
    }
}
