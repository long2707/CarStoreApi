using AutoMapper;
using CarStoreApi.Application.DTOS.Role;
using CarStoreApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.UserNames, opt => opt.Ignore());
        }
    }
}
