using Garage3._0.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage3._0.Web.Services
{
    public interface IVehicleTypeService
    {
        Task<IEnumerable<SelectListItem>> GetVehicleTypes(int? selectedId);
    }
}