using Microsoft.EntityFrameworkCore;
using Garage3._0.Web.Models.Entities;

namespace Garage3._0.Web.Data;

public class GarageContext : DbContext
{
    public GarageContext(DbContextOptions<GarageContext> options)
        : base(options)
    {

    }
    public DbSet<Garage3._0.Web.Models.Entities.VehicleTypeEntities> VehicleTypeEntities { get; set; }
}
