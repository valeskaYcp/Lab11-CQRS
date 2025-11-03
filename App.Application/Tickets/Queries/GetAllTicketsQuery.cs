using App.Application.Tickets.DTOs;
using MediatR;

namespace App.Application.Tickets.Queries;

public record GetAllTicketsQuery() : IRequest<IEnumerable<TicketDto>>;
