#nullable disable
namespace Garage3._0.Web.Models.Entities;

public class VehicleEntity
{
    public int Id { get; set; }
    public string RegNo { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public int Member { get; set; }
    public int VehicleType { get; set; }

    public string? Color { get; set; }
}
