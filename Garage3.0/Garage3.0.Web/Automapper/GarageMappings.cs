using AutoMapper;
using Garage3._0.Web.Models.Entities;
using Garage3._0.Web.Models.ViewModels;

namespace Garage3._0.Web.Automapper;

public class GarageMappings : Profile
{
    public GarageMappings()
    {
        CreateMap<MemberEntity, MemberCreateViewModel>().ReverseMap();
        CreateMap<MemberEntity, MemberIndexViewModel>();
        CreateMap<MemberViewModel, MemberEntity>().ReverseMap();
        CreateMap<VehicleTypeViewModel, VehicleTypeEntity>().ReverseMap();
        CreateMap<VehicleEntity, VehicleViewModel>().ReverseMap();
        CreateMap<VehicleCreateViewModel, VehicleEntity>();
        CreateMap<VehicleEditViewModel, VehicleEntity>().ReverseMap();
        CreateMap<ParkingSpotViewModel, ParkingSpotEntity>().ReverseMap();
        CreateMap<ParkingActivityCheckInViewModel, ParkingActivityEntity>();
        CreateMap<ParkingActivityEntity, ParkingActivityIndexViewModel>();

    }
}
