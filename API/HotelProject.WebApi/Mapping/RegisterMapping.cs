using AutoMapper;
using HotelProject.DtoLayer.Dtos.AppUserDto;
using HotelProject.EntityLayer;

namespace HotelProject.WebApi.Mapping
{
    public class RegisterMapping : Profile
    {
        public RegisterMapping()
        {
            CreateMap<ResultAppUserDto, AppUser>().ReverseMap();
        }
    }
}
