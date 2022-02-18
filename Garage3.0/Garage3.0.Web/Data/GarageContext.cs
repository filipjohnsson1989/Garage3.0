#nullable disable
using Microsoft.EntityFrameworkCore;
using Garage3._0.Web.Models.Entities;

namespace Garage3._0.Web.Data;

public class GarageContext : DbContext
{
    public DbSet<VehicleEntity> VehicleEntity { get; set; }

    public DbSet<VehicleTypeEntity> VehicleTypeEntity { get; set; }

    public DbSet<MemberEntity> MemberEntity { get; set; }

    public GarageContext(DbContextOptions<GarageContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VehicleEntity>()
            .HasOne(v => v.VehicleTypeEntity)
            .WithMany(vt => vt.Vehicles)
            .IsRequired();
        modelBuilder.Entity<VehicleEntity>()
            .HasOne(v => v.MemberEntity)
            .WithMany(m => m.Vehicles)
            .IsRequired();
        //base.OnModelCreating(modelBuilder); 
    }
}
