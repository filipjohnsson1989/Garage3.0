using Garage3._0.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage3._0.Web.Services
{
    public interface IParkingSpotService
    {
        Task<IEnumerable<SelectListItem>> GetParkingSpots(int? selectedId);
    }
}