using AutoMapper;
using CarStoreApi.Application.DTOS.Feature;
using CarStoreApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.Profiles
{
    public class FeatureProfile : Profile
    {
        public FeatureProfile()
        {
            CreateMap<Feature, FeatureDto>();
            CreateMap<AddFeatureDto, Feature>()
                .ForMember(dest => dest.FeatureId, opt => opt.Ignore())
                .ForMember(dest => dest.CarFeatures, opt => opt.Ignore());
        }
    }
}
