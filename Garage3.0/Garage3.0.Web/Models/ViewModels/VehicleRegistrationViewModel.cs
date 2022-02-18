using Garage3._0.Web.Models.Entities;

namespace Garage3._0.Web.Models.ViewModels
{
    public record VehicleRegistrationViewModel (string RegNo, string Brand, string Model, string? Color, VehicleTypeEntity VehicleType, MemberEntity Member);
    
}
