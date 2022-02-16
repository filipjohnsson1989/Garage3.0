using Garage3._0.Web.Models.Entities;

namespace Garage3._0.Web.Models.ViewModels
{
    public class MemberRegistrationViewModel
    {
        public string Name { get; set; }
        public int PersonNr { get; set; }
        public string Email { get; set; }

        //Nav prop
        public ICollection<VehicleEntity> Vehicles { get; set; } = new List<VehicleEntity>();
    }
}
