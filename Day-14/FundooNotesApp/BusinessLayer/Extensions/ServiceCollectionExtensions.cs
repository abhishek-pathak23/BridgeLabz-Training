using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;

namespace BusinessLayer.Extensions;

/// <summary>
/// Day-14: Centralized DI registration for all application services.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFundooApplicationServices(this IServiceCollection services)
    {
        // ─── Repository Layer (Scoped) ────────────────────────────────────────
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<INoteRepository, NoteRepository>();

        // ─── Business Layer (Scoped) ──────────────────────────────────────────
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<INoteService, NoteService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
