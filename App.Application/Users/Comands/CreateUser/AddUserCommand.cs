using MediatR;

namespace App.Application.Users.Comands.CreateUser;

public class AddUserCommand : IRequest<Guid>
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Guid RoleId { get; set; }
}
