using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace Presentation.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<DeviceDtoForInsertion, Device>();
            CreateMap<DeviceDtoForUpdate, Device>().ReverseMap();
            CreateMap<RegisterDto, AppUser>();
        }
    }
}
