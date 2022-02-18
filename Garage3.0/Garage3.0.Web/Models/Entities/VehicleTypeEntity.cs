#nullable disable
namespace Garage3._0.Web.Models.Entities
{
    public class VehicleTypeEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Wheels { get; set; }
        public ICollection<VehicleEntity> Vehicles { get; set; }


    }
}
