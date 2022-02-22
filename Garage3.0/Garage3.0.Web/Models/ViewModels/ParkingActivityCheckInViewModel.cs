using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Web.Models.ViewModels;

public class ParkingActivityCheckInViewModel
{
    [Required]
    [Display(Name = "ParkingSpot")]
    public ParkingSpotViewModel ParkingSpot { get; set; }

    [Required]
    [Display(Name = "Vehicle")]
    public VehicleViewModel Vehicle { get; set; }

    //public int VehicleId { get; set; }

}
