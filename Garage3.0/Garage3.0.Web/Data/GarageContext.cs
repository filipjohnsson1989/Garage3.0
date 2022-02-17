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
    public DbSet<Garage3._0.Web.Models.Entities.VehicleType> VehicleType { get; set; }
}
