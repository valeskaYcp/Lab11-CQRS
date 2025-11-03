using App.Application.Response.Comands.CreateResponse;
using App.Application.Response.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_ValeskaCondori.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResponsesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResponsesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CrearRespuesta(AddResponseCommand command)
    {
        try
        {
            var responseId = await _mediator.Send(command);
            return Ok(new
            {
                Exito = true,
                Mensaje = "Respuesta creada correctamente",
                IdRespuesta = responseId
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Exito = false,
                Mensaje = "Error al crear la respuesta",
                Detalles = ex.Message
            });
        }
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodasLasRespuestas()
    {
        try
        {
            var responses = await _mediator.Send(new GetAllResponsesQuery());
            return Ok(new
            {
                Exito = true,
                Mensaje = "Respuestas obtenidas correctamente",
                Datos = responses
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Exito = false,
                Mensaje = "Error al obtener las respuestas",
                Detalles = ex.Message
            });
        }
    }
}