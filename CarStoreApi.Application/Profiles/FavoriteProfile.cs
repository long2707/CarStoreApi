using AutoMapper;
using CarStoreApi.Application.DTOS.Favorite;
using CarStoreApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.Profiles
{
    public class FavoriteProfile : Profile
    {
        public FavoriteProfile()
        {
            CreateMap<ToggleFavoriteDto, Favorite>();
        }
    }
}
