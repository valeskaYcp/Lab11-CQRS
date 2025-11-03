using App.Application.Tickets.Comands.CreateTickets;
using App.Application.Tickets.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_ValeskaCondori.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTicket(AddTicketCommand command)
    {
        try
        {
            var ticketId = await _mediator.Send(command);

            if (ticketId == Guid.Empty)
                return BadRequest(new { message = "No se pudo crear el ticket." });

            return CreatedAtAction(nameof(GetAllTickets), new { id = ticketId },
                new { message = "Ticket creado exitosamente.", ticketId });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Error al crear el ticket.", details = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTickets()
    {
        try
        {
            var tickets = await _mediator.Send(new GetAllTicketsQuery());

            if (tickets == null || !tickets.Any())
                return Ok(new { message = "No hay tickets registrados.", data = tickets });

            return Ok(new { message = "Tickets obtenidos exitosamente.", data = tickets });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Error al obtener los tickets.", details = ex.Message });
        }
    }
}