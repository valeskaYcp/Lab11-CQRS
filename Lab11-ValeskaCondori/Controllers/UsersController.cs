using App.Application.Users.Comands.CreateUser;
using App.Application.Users.DTOs;
using App.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_ValeskaCondori.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] AddUserCommand command)
    {
        try
        {
            var userId = await _mediator.Send(command);
            return Ok(new
            {
                success = true,
                message = "Usuario creado exitosamente",
                data = new { UserId = userId }
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                success = false,
                message = $"Error al crear el usuario: {ex.Message}"
            });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(new
            {
                success = true,
                message = "Usuarios obtenidos correctamente",
                data = users
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                success = false,
                message = $"Error al obtener los usuarios: {ex.Message}"
            });
        }
    }
}