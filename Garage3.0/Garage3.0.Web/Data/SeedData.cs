using Microsoft.EntityFrameworkCore;
using Garage3._0.Web.Models.Entities;
using Bogus;

namespace Garage3._0.Web.Data
{
    public class SeedData
    {
        private static Faker faker = default!;

        private static async Task InitVehicleTypeAsync(GarageContext db)
        {
            if (await db.VehicleTypes.AnyAsync()) return;

            var vehicleTypes = GetVehicleTypes();
            await db.AddRangeAsync(vehicleTypes);
        }

        private static async Task InitParkingSpotsAsync(GarageContext db)
        {
            if (await db.ParkingSpots.AnyAsync()) return;

            var parkingSpots = GetParkingSpots();
            await db.AddRangeAsync(parkingSpots);
        }

        public static async Task InitAsync(GarageContext db)
        {
            faker = new Faker("sv");

            await InitVehicleTypeAsync(db);
            await InitParkingSpotsAsync(db);

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

        private static IEnumerable<ParkingSpotEntity> GetParkingSpots()
        {
            var parkingSpots = new List<ParkingSpotEntity>();

            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "A1" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "A2" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "A3" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "A4" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "A5" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "A6" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "A7" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "A8" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "A9" });

            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "B1" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "B2" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "B3" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "B4" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "B5" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "B6" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "B7" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "B8" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "B9" });

            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "C1" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "C2" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "C3" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "C4" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "C5" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "C6" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "C7" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "C8" });
            parkingSpots.Add(new ParkingSpotEntity { SpotNumber = "C9" });

            return parkingSpots;
        }
    }
}