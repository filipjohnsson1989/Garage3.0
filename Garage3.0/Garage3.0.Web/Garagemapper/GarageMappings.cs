using AutoMapper;
using Garage3._0.Web.Models.Entities;
using Garage3._0.Web.Models.ViewModels;

namespace Garage3._0.Web.Garagemapper;

public class GarageMappings : Profile
{
    public GarageMappings()
    {
        CreateMap<MemberEntity, MemberCreateViewModel>(); 
    }
}
