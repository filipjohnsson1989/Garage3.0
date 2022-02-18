#nullable disable
namespace Garage3._0.Web.Models.Entities;

public class VehicleEntity
{
    public int Id { get; set; }
    public string RegNo { get; set; }

    public string Brand { get; set; }
    public VehicleTypeEntity VehicleType { get; set; }
    public MemberEntity Member { get; set; }

    public string Model { get; set; }
    public string? Color { get; set; }
}
