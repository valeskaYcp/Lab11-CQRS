using MediatR;

namespace App.Application.Tickets.Comands.CreateTickets;

public record AddTicketCommand(Guid UserId, string Title, string? Description) : IRequest<Guid>;
