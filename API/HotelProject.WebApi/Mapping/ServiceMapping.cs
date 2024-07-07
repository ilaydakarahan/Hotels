using AutoMapper;
using HotelProject.DtoLayer.Dtos.ServiceDto;
using HotelProject.EntityLayer;

namespace HotelProject.WebApi.Mapping
{
    public class ServiceMapping : Profile
    {
        public ServiceMapping()
        {
            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<ResultServiceDto, Service>().ReverseMap();
        }
    }
}
