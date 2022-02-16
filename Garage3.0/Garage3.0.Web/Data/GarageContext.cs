using Microsoft.EntityFrameworkCore;

namespace Garage3._0.Web.Data;

public class GarageContext : DbContext
{
    public GarageContext(DbContextOptions<GarageContext> options)
        : base(options)
    {

    }
}
