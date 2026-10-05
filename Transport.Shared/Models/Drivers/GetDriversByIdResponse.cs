using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Shared.Models.Drivers
{
    public class GetDriversByIdResponse
    {
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? Telefon { get; set; }
        public string? Email { get; set; }
        public bool? AktifMi { get; set; }
    }
}
