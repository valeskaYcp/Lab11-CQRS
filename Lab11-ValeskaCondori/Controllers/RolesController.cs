using App.Application.Roles.Comands.CreateRole;
using App.Application.Roles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_ValeskaCondori.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddRoleCommand command)
    {
        try
        {
            var id = await _mediator.Send(command);
            return Ok(new 
            { 
                success = true,
                message = "Rol creado exitosamente",
                data = new { RoleId = id }
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new 
            { 
                success = false,
                message = $"Error al crear el rol: {ex.Message}" 
            });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var roles = await _mediator.Send(new GetAllRolesQuery());
            return Ok(new 
            {
                success = true,
                message = "Roles obtenidos correctamente",
                data = roles
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                success = false,
                message = $"Error al obtener los roles: {ex.Message}"
            });
        }
    }
}