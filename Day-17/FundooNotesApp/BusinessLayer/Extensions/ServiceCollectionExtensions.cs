using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;

namespace BusinessLayer.Extensions;

/// <summary>
/// Day-14: Centralized DI registration for all application services.
/// Day-16: Added ILabelRepository → LabelRepository and ILabelService → LabelService.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFundooApplicationServices(this IServiceCollection services)
    {
        // ─── Repository Layer (Scoped) ────────────────────────────────────────
        services.AddScoped<IUserRepository,  UserRepository>();
        services.AddScoped<INoteRepository,  NoteRepository>();
        services.AddScoped<ILabelRepository, LabelRepository>();

        // ─── Business Layer (Scoped) ──────────────────────────────────────────
        services.AddScoped<IPasswordHasher,    PasswordHasher>();
        services.AddScoped<IAuthService,       AuthService>();
        services.AddScoped<INoteService,       NoteService>();
        services.AddScoped<ILabelService,      LabelService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IUserService,       UserService>();

        // ─── Day-17: RabbitMQ Producer (Singleton — one connection for the app) ──
        services.AddSingleton<IRabbitMqProducer, RabbitMqProducer>();

        return services;
    }
}
