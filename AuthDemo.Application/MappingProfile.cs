using AutoMapper;
using AuthDemo.Application.Dtos.Authentication;
using AuthDemo.Domain.Entities.Authentication;
using System;

namespace AuthDemo.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterRequest, User>()
                .ForMember(m => m.SecurityStamp, opt => opt.MapFrom(src => Guid.NewGuid().ToString()));

            CreateMap<User, UserResponse>();
        }
    }
}
