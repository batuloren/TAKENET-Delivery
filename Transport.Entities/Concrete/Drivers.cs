using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Transport.Entities.Concrete;

[Index("Email", Name = "UQ__Drivers__AB6E6164628CF813", IsUnique = true)]
public partial class Drivers
{
    [Key]
    public Guid id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Ad { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Soyad { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Telefon { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    public bool AktifMi { get; set; }

    public string FullName => $"{Ad} {Soyad}";

    [InverseProperty("Driver")]
    public virtual ICollection<Shipments> Shipments { get; set; } = new List<Shipments>();
}
