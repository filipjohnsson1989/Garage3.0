using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage3._0.Web.Models.Entities
{
    public class ParkingActivityEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime? CheckOut { get; set; }

        public double? ParkingCost { get; set; }

        //Nav prop

        //[ForeignKey("Id")]
        public int VehicleEntityId { get; set; }
        public VehicleEntity Vehicle { get; set; }

        public int ParkingSpotId { get; set; }
        public ParkingSpot ParkingSpot { get; set; }

    }
}
