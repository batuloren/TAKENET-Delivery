using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Transport.Entities.Concrete;

[Index("Email", Name = "UQ__Customer__AB6E6164D5C09790", IsUnique = true)]
public partial class Customers
{
    [Key]
    public Guid id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Ad { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Soyad { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string Telefon { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    public bool AktifMi { get; set; }

    public string FullName => $"{Ad} {Soyad}";

    [InverseProperty("Customer")]
    public virtual ICollection<Shipments> Shipments { get; set; } = new List<Shipments>();
}
