using Microsoft.EntityFrameworkCore;
using Garage3._0.Web.Models.Entities;
using Bogus;

namespace Garage3._0.Web.Data
{
    public class SeedData
    {
        private static Faker faker = null;
        public static async Task InitAsync(GarageContext db)
        {
            if (await db.VehicleTypes.AnyAsync()) return;

            faker = new Faker("sv");

            var vehicleTypes = GetVehicleTypes();
            await db.AddRangeAsync(vehicleTypes);

            await db.SaveChangesAsync();
        }

        private static IEnumerable<VehicleTypeEntity> GetVehicleTypes()
        {
            var vehicleTypes = new List<VehicleTypeEntity>();

            vehicleTypes.Add(new VehicleTypeEntity { Title = "Bil", Wheels = 4 });
            vehicleTypes.Add(new VehicleTypeEntity { Title = "Båt", Wheels = 0 });
            vehicleTypes.Add(new VehicleTypeEntity { Title = "Cykel", Wheels = 2 });
            vehicleTypes.Add(new VehicleTypeEntity { Title = "Motorcykel", Wheels = 2 });
            vehicleTypes.Add(new VehicleTypeEntity { Title = "Flygplan", Wheels = 3 });






            return vehicleTypes;
        }
    }
}
