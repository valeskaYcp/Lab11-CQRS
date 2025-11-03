using App.Application.UserRoles.Comands.CreateUserRoles;
using App.Application.UserRoles.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_ValeskaCondori.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserRolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserRolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("assign")]
    public async Task<IActionResult> AssignRole([FromBody] AssignRoleCommand command)
    {
        var result = await _mediator.Send(command);
        if (result)
            return Ok(new { Message = "Rol asignado correctamente" });
        return BadRequest(new { Message = "Error al asignar el rol" });
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserRoleDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllUserRolesQuery());
        return Ok(result);
    }
}