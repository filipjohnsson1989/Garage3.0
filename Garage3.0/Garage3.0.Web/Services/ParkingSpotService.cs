using AutoMapper;
using Garage3._0.Web.Data;
using Garage3._0.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage3._0.Web.Services;

public class ParkingSpotService : IParkingSpotService
{
    private readonly GarageContext _context;

    public ParkingSpotService(GarageContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SelectListItem>> GetParkingSpots(int? selectedId)
        => await _context.ParkingSpots.Select(parkingSpot => new SelectListItem() { Text = parkingSpot.SpotNumber, Value = parkingSpot.Id.ToString(), Selected = parkingSpot.Id == selectedId, Disabled = (parkingSpot.ParkingActivitys.FirstOrDefault() != null) }).ToListAsync();



}
