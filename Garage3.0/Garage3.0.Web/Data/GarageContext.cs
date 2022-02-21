#nullable disable
using Microsoft.EntityFrameworkCore;
using Garage3._0.Web.Models.Entities;

namespace Garage3._0.Web.Data;

public class GarageContext : DbContext
{
    public DbSet<VehicleEntity> Vehicles { get; set; }

    public DbSet<VehicleTypeEntity> VehicleTypes { get; set; }

    public DbSet<MemberEntity> Members { get; set; }

    public DbSet<ParkingSpotEntity> ParkingSpots { get; set; }

    public DbSet<ParkingActivityEntity> ParkingActivities { get; set; } 

    public GarageContext(DbContextOptions<GarageContext> options)
        : base(options)
    {
        
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MemberEntity>()
               .Property(u => u.Name)
               .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

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
}

