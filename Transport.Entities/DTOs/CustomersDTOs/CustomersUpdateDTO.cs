using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Entities.DTOs.CustomersDTOs
{
    public class CustomersUpdateDTO
    {
        public string Ad { get; set; } = null!;
        public string Soyad { get; set; } = null!;
        public string Telefon { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
