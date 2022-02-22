#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Web.Models.ViewModels;

//ToDo: It doesn't work with Auto-mapper (Usage in controller)
//public record VehicleIndexViewModel(int Id, string MemberName, string VehicleTypeTitle, string RegNo, string Brand, string Model, string? Color);

public class VehicleViewModel
{
    public int Id { get; set; }
    [Display(Name = "Member")]
    public string MemberName { get; set; }
    [Display(Name = "Vehicle Type")]
    public string VehicleTypeTitle { get; set; }
    public string RegNo { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }


#nullable enable
    public string? Color { get; set; }


}

