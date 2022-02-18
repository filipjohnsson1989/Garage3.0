#nullable disable
namespace Garage3._0.Web.Models.ViewModels;

public class VehicleCreateViewModel
{
    public int Id { get; set; }
    public int MemberId { get; set; }
    public int VehicleTypeId { get; set; }
    public string RegNo { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }


#nullable enable
    public string? Color { get; set; }
}
