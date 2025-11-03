using App.Application.UserRoles.Comands.CreateUserRoles;
using App.Application.UserRoles.DTOs;
using App.Domain.Roles.Interfaces;
using App.Domain.UserRole.Interfaces;
using AutoMapper;
using MediatR;

namespace App.Application.UserRoles.Queries;

public class GetAllUserRolesQueryHandler : IRequestHandler<GetAllUserRolesQuery, IEnumerable<UserRoleDto>>
{
    private readonly IUserRoleRepository _repository;
    private readonly IMapper _mapper;

    public GetAllUserRolesQueryHandler(IUserRoleRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserRoleDto>> Handle(GetAllUserRolesQuery request, CancellationToken cancellationToken)
    {
        var userRoles = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserRoleDto>>(userRoles);
    }
}