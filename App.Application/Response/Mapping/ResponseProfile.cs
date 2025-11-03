using App.Application.Response.DTOs;
using AutoMapper;

namespace App.Application.Response.Mapping;

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<Infrastructure.Models.Response, ResponseDto>()
            .ForMember(dest => dest.ResponderName, opt => opt.MapFrom(src => src.Responder.Username))
            .ForMember(dest => dest.TicketTitle, opt => opt.MapFrom(src => src.Ticket.Title));
    }
}