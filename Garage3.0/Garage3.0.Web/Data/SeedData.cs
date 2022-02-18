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
            if (await db.VehicleTypeEntity.AnyAsync()) return;

            faker = new Faker("sv");

            var vehicleTypes = GetVehicleTypes();
            await db.AddRangeAsync(vehicleTypes);

            await db.SaveChangesAsync();
        }

        private static IEnumerable<VehicleTypeEntity> GetVehicleTypes()
        {
            var vehicleTypes = new List<VehicleTypeEntity>();

            vehicleTypes.Add(new VehicleTypeEntity { Title = "Car", Wheels = 4 });
            vehicleTypes.Add(new VehicleTypeEntity { Title = "Boat", Wheels = 0 });
            vehicleTypes.Add(new VehicleTypeEntity { Title = "Bicycle", Wheels = 2 });
            vehicleTypes.Add(new VehicleTypeEntity { Title = "MC", Wheels = 2 });
            vehicleTypes.Add(new VehicleTypeEntity { Title = "Airplane", Wheels = 3 });






            return vehicleTypes;
        }
    }
}
