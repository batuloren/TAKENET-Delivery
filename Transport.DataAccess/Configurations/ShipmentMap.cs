using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Entities.Concrete;

namespace Transport.DataAccess.Configurations
{
    public class ShipmentMap : IEntityTypeConfiguration<Shipments>
    {
        public void Configure(EntityTypeBuilder<Shipments> entity)
        {
            entity.HasKey(e => e.id);

            entity.Property(e => e.id)
                 .IsRequired()
                 .HasDefaultValueSql("newId()");

            entity.Property(e => e.Agirlik)
                  .HasColumnType("decimal");

            entity.Property(e => e.LoadAddress)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(e => e.DeliveryAddress)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(e => e.ShipmentDate)
                   .HasColumnType("datetime");

            entity.Property(e => e.Description)
                  .HasColumnType("text");

            entity.Property(e => e.FeedbackDescription)
                  .HasColumnType("text");

            entity.Property(e => e.trackId)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(e => e.AktifMi)
                  .IsRequired()
                  .HasColumnType("bit")
                  .HasDefaultValue(true);

            entity.Ignore("createdAt");

            entity.HasOne(c => c.Customer)
                  .WithMany(s => s.Shipments)
                  .HasForeignKey(c => c.CustomerId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Driver)
                  .WithMany(s => s.Shipments)
                  .HasForeignKey(d => d.DriverId)
                  .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasOne(v => v.Vehicle)
                  .WithMany(s => s.Shipments)
                  .HasForeignKey(v => v.VehicleId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(st => st.Status)
                  .WithMany(s => s.Shipments)
                  .HasForeignKey(st => st.StatusId)
                  .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
