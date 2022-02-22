using AutoMapper;
using Garage3._0.Web.Data;
using Garage3._0.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage3._0.Web.Services;

public class VehicleTypeService : IVehicleTypeService
{
    private readonly GarageContext _context;

    public VehicleTypeService(GarageContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SelectListItem>> GetVehicleTypes(int? selectedId)
        => await _context.VehicleTypes.Select(vehicleType => new SelectListItem() { Text = vehicleType.Title, Value = vehicleType.Id.ToString(), Selected = vehicleType.Id == selectedId }).ToListAsync();



}
