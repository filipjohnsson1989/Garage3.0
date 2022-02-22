using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Web.Models.ViewModels;

public class ParkingActivityIndexViewModel
{
    public int Id { get; set; }
    [Display(Name = "Spot Number")]
    public string ParkingSpotSpotNumber { get; set; }


    [Display(Name = "Vehicle RegNo")]
    public string VehicleRegNo { get; set; }
    
    [Display(Name = "Vehicle Type")]
    public string VehicleVehicleTypeTitle { get; set; }

    [Display(Name = "Member")]
    public string VehicleMemberName { get; set; }
    public DateTime CheckIn { get; set; }

    public DateTime? CheckOut { get; set; }

    public double? ParkingCost { get; set; }


}
