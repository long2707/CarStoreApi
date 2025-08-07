using AutoMapper;
using CarStoreApi.Application.DTOS.Car;
using CarStoreApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.Profiles
{
    public class CarProfile:Profile
    {
        public CarProfile()
        {
            CreateMap<CarModel, CarDto>()
                .ForMember(dest => dest.CarBrand, opt => opt.Ignore())
                .ForMember(dest => dest.ImagesUrls, opt => opt.Ignore())
                .ForMember(dest => dest.IsLiked, opt => opt.Ignore());
            CreateMap<CarBrand, BrandDto>();

            CreateMap<AddCarDto, CarModel>()
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.Rates, opt => opt.Ignore())
                .ForMember(dest => dest.CarFeatures, opt => opt.Ignore())
                .ForMember(dest => dest.Favorites, opt => opt.Ignore())
                .ForMember(dest => dest.ModelGalleries, opt => opt.Ignore());

            CreateMap<UpdateCarDto, CarModel>()
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.Rates, opt => opt.Ignore())
                .ForMember(dest => dest.CarFeatures, opt => opt.Ignore())
                .ForMember(dest => dest.Favorites, opt => opt.Ignore())
                .ForMember(dest => dest.ModelGalleries, opt => opt.Ignore());
        }
    }
}
