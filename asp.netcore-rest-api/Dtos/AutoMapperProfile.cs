using asp.netcore_rest_api.Models;
using AutoMapper;

namespace asp.netcore_rest_api.Dtos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreatePersonDto, Person>();
            CreateMap<UpdatePersonDto, Person>();
        }
    }
}
