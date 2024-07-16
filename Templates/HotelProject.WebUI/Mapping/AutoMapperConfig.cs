using AutoMapper;
using HotelProject.EntityLayer;
using HotelProject.WebUI.Dtos.AppUserDto;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
       public AutoMapperConfig()
        {
            CreateMap<ResultAppUserDto, AppUser>().ReverseMap();
        }

    }
}
