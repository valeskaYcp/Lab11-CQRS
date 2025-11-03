using App.Application.Tickets.DTOs;
using App.Infrastructure.Models;
using AutoMapper;

namespace App.Application.Tickets.Mapping;

public class TicketProfile : Profile
{
    public TicketProfile()
    {
        CreateMap<Ticket, TicketDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username));
    }
}
