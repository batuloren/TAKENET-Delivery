using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Transport.Entities.Concrete;

public partial class Vehicles
{
    [Key]
    public Guid id { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string PlakaNumara { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string AracModel { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal AracKapasite { get; set; }

    public bool AktifMi { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AracBoyut { get; set; } 

    [InverseProperty("Vehicle")]
    public virtual ICollection<Shipments> Shipments { get; set; } = new List<Shipments>();
}
