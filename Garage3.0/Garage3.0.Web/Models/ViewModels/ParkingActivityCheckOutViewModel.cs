using Garage3._0.Web.Common;
using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Web.Models.ViewModels;

public class ParkingActivityCheckOutViewModel
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

    //public DateTime? CheckOut { get; set; }

    //public double? ParkingCost { get; set; }

    [Display(Name = "Parking Period")]
    public string ParkingTime
    {
        get
        {
            return Util.ParkingTimeString(CheckIn, DateTime.Now);
        }
    }

    [Display(Name = "Cost")]
    public string Price
    {
        get
        {
            return String.Format(" {0:C2}", Util.ParkingTimeCost(CheckIn, DateTime.Now, HourlyCost));
        }
    }

    [Display(Name = "Cost per hour")]
    public double HourlyCost { get; internal set; }


}
