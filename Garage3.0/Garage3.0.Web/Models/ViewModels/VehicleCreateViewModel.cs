using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Web.Models.ViewModels;

public class VehicleCreateViewModel
{
    [Required]
    [Display(Name = "Member")]
    public MemberViewModel Member { get; set; }

    [Required]
    [Display(Name = "Vehicle Type")]
    public VehicleTypeViewModel VehicleType { get; set; }
    public string RegNo { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }


    public string? Color { get; set; }
}
