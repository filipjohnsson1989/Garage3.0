#nullable disable
using Microsoft.EntityFrameworkCore;
using Garage3._0.Web.Models.Entities;

namespace Garage3._0.Web.Data;

public class GarageContext : DbContext
{
    public DbSet<VehicleEntity> VehicleEntity { get; set; }

    public GarageContext(DbContextOptions<GarageContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VehicleEntity>()
            .HasOne(p => p.VehicleType)
            .WithMany(b => b.Vehicles)
            .IsRequired();
        //base.OnModelCreating(modelBuilder); 
    }
    public DbSet<Garage3._0.Web.Models.Entities.VehicleTypeEntity> VehicleTypeEntity { get; set; }
}
