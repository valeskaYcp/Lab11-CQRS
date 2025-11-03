using App.Application.Tickets.DTOs;
using App.Domain.Tickets.Interfaces;
using AutoMapper;
using MediatR;

namespace App.Application.Tickets.Queries;

public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, IEnumerable<TicketDto>>
{
    private readonly ITicketRepository _repository;
    private readonly IMapper _mapper;

    public GetAllTicketsQueryHandler(ITicketRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TicketDto>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        var tickets = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<TicketDto>>(tickets);
    }
}
