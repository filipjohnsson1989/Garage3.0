namespace Garage3._0.Web.Models.Entities
{
    public class ParkingSpot
    {
        public int Id { get; set; }

        public string SpotNumber { get; set; }

        public bool IsAvailable { get; set; }

        public VehicleEntity ParkedVehicle { get; set; }

        public void Park(VehicleEntity vehcile)
        {
            if (this.ParkedVehicle == null)
            {
                this.ParkedVehicle = vehcile;
                this.IsAvailable = false;
            }
            else
            {
                throw new Exception("Parking Spot is taken!");
            }
        }

        public ParkingSpot()
        {
            this.IsAvailable = true;
        }

        public ICollection<ParkingActivityEntity> ParkingActivityEntities { get; set; }
    }
}
