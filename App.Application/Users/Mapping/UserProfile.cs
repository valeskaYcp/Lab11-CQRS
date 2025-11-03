using AutoMapper;
using App.Application.Users.DTOs;
using App.Infrastructure.Models;
using System.Linq;

namespace App.Application.Users.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => 
                    src.UserRoles.FirstOrDefault() != null ? src.UserRoles.First().Role.RoleName : string.Empty));

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.UserRoles, opt => opt.Ignore()); 
        }
    }
}