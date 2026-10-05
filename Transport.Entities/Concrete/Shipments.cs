using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Transport.Entities.Concrete;

public partial class Shipments
{
    [Key]
    public Guid id { get; set; }

    public Guid? CustomerId { get; set; }

    public Guid? VehicleId { get; set; }

    public Guid? DriverId { get; set; }

    public Guid? StatusId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Agirlik { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string LoadAddress { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string DeliveryAddress { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? ShipmentDate { get; set; }

    public int StatusCode { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    public string? FeedbackDescription { get; set; }

    public string trackId { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public bool AktifMi { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Shipments")]
    public virtual Customers? Customer { get; set; }

    [ForeignKey("DriverId")]
    [InverseProperty("Shipments")]
    public virtual Drivers? Driver { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("Shipments")]
    public virtual Statuses? Status { get; set; }

    [ForeignKey("VehicleId")]
    [InverseProperty("Shipments")]
    public virtual Vehicles? Vehicle { get; set; }
}
