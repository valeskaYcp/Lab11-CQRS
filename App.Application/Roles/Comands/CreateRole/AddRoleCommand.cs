using MediatR;

namespace App.Application.Roles.Comands.CreateRole;
public record AddRoleCommand(string RoleName) : IRequest<Guid>;