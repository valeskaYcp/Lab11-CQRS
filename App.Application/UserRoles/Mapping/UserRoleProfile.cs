using AutoMapper;
using App.Application.UserRoles.DTOs;
using App.Infrastructure.Models;

namespace App.Application.UserRoles.Mapping;

public class UserRoleProfile : Profile
{
    public UserRoleProfile()
    {
        CreateMap<UserRole, UserRoleDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username))
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName))
            .ForMember(dest => dest.AssignedAt, opt => opt.MapFrom(src => src.AssignedAt ?? DateTime.MinValue)); 
    }
}