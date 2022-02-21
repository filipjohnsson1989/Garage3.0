#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Web.Models.ViewModels;

public class VehicleCreateViewModel
{
    public int MemberId { get; set; }
    [Display(Name = "Vehicle Type")]
    public int VehicleTypeId { get; set; }
    public string RegNo { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }


#nullable enable
    public string? Color { get; set; }
}
