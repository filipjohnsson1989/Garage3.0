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

            vehicleTypes.Add(new VehicleTypeEntity { Title = "Car", Wheels = 4 });
            vehicleTypes.Add(new VehicleTypeEntity { Title = "Boat", Wheels = 0 });
            vehicleTypes.Add(new VehicleTypeEntity { Title = "Bicycle", Wheels = 2 });
            vehicleTypes.Add(new VehicleTypeEntity { Title = "MC", Wheels = 2 });
            vehicleTypes.Add(new VehicleTypeEntity { Title = "Airplane", Wheels = 3 });


            return vehicleTypes;
        }

        private static IEnumerable<ParkingSpot> GetParkingSpots()
        {
            var parkingSpots = new List<ParkingSpot>();

            parkingSpots.Add(new ParkingSpot { SpotNumber = "A1" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "A2" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "A3" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "A4" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "A5" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "A6" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "A7" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "A8" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "A9" });

            parkingSpots.Add(new ParkingSpot { SpotNumber = "B1" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "B2" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "B3" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "B4" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "B5" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "B6" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "B7" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "B8" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "B9" });

            parkingSpots.Add(new ParkingSpot { SpotNumber = "C1" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "C2" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "C3" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "C4" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "C5" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "C6" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "C7" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "C8" });
            parkingSpots.Add(new ParkingSpot { SpotNumber = "C9" });

            return parkingSpots;
        }
    }
}