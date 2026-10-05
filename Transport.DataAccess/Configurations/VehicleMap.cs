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
    public class VehicleMap : IEntityTypeConfiguration<Vehicles>
    {
        public void Configure(EntityTypeBuilder<Vehicles> entity)
        {
            entity.HasKey(e => e.id);

            entity.Property(e => e.id)
                  .IsRequired()
                  .HasDefaultValueSql("newId()");

            entity.Property(e => e.PlakaNumara)
                  .IsRequired()
                  .HasMaxLength(30);

            entity.Property(e => e.AracModel)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(e => e.AracKapasite)
                  .IsRequired()
                  .HasColumnType("decimal");

            entity.Property(e => e.AracBoyut)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(e => e.AktifMi)
                  .IsRequired()
                  .HasColumnType("bit")
                  .HasDefaultValue(true);

        }
    }
}
