using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Transport.Entities.Concrete;

public partial class Statuses
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Durum { get; set; }

    public int StatusCode { get; set; }

    public bool AktifMi {  get; set; }

    [InverseProperty("Status")]
    public virtual ICollection<Shipments> Shipments { get; set; } = new List<Shipments>();
}
