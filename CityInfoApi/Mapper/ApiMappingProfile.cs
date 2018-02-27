using System;
using AutoMapper;
using CityInfoApi.Model;

namespace CityInfoApi.Mapper
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<UpdatePointOfInterestDto, PointOfInterestDto>()
                .ForMember(dest=>dest.Id, options=>options.Ignore())

            ;
        }
    }
}
