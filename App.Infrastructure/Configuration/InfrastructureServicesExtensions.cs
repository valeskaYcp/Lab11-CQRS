using App.Domain.Response.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using App.Domain.Roles.Interfaces;
using App.Domain.Tickets.Interfaces;
using App.Domain.User.Interfaces;
using App.Domain.UserRole.Interfaces;
using App.Infrastructure.Data;
using App.Infrastructure.Repositories;
using App.Infrastructure.Response.Repositories;
using App.Infrastructure.Roles.Repositories;
using App.Infrastructure.Tickets.Repositories;
using App.Infrastructure.UserRole.Repositories;
using App.Infrastructure.Users.Repositories;

namespace App.Infrastructure.Configuration;

public static class InfrastructureServicesExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        // Registrar DbContext con PostgreSQL
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("TicketeraDBConnection")));

        // Repositorios y UnitOfWork
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<IResponseRepository, ResponseRepository>();

        return services;
    }
}