#nullable disable
using Microsoft.EntityFrameworkCore;
using Garage3._0.Web.Models.Entities;

namespace Garage3._0.Web.Data;

public class GarageContext : DbContext
{
    public DbSet<VehicleEntity> Vehicles { get; set; }

    public DbSet<VehicleTypeEntity> VehicleTypes { get; set; }

    public DbSet<MemberEntity> Members { get; set; }

    public GarageContext(DbContextOptions<GarageContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<Garage3._0.Web.Models.Entities.ParkingSpot> ParkingSpot { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VehicleEntity>()
            .HasOne(v => v.VehicleType)
            .WithMany(vt => vt.Vehicles)
            .IsRequired();
        modelBuilder.Entity<VehicleEntity>()
            .HasOne(v => v.Member)
            .WithMany(m => m.Vehicles)
            .IsRequired();
        //base.OnModelCreating(modelBuilder); 
    }
