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

            CreateMap<PointOfInterestDto, UpdatePointOfInterestDto>();
            //since id is is present only in the source but no in the destination
            //there is no need to have any additonal statements 



            CreateMap<UpdatePointOfInterestDto, PointOfInterestDto>()
                .ForMember(dest=>dest.Id, options=>options.Ignore())
            ;


        }
    }
}
