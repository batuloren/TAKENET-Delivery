using Microsoft.EntityFrameworkCore;
using Transport.Entities.Concrete;

namespace Transport.DataAccess;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customers> Customers { get; set; }
    public virtual DbSet<Drivers> Drivers { get; set; }
    public virtual DbSet<Shipments> Shipments { get; set; }
    public virtual DbSet<Statuses> Statuses { get; set; }
    public virtual DbSet<Vehicles> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}