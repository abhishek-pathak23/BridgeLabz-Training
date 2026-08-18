using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;

namespace BusinessLayer.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers all application business and data layer services in the DI container.
    /// Demonstrates structured Dependency Injection configuration.
    /// </summary>
    public static IServiceCollection AddFundooApplicationServices(this IServiceCollection services)
    {
        // 1. Data Access / Repository Layer Services (Scoped lifecycle)
        services.AddScoped<IUserRepository, UserRepository>();

        // 2. Business Layer Services (Scoped lifecycle)
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        // 3. Dependency Injection Deep-Dive Lifecycle Services
        // Transient: New instance on every resolve
        services.AddTransient<ITransientLifecycleService, TransientLifecycleService>();

        // Scoped: Reused throughout a single HTTP request scope
        services.AddScoped<IScopedLifecycleService, ScopedLifecycleService>();

        // Singleton: Reused across all requests and throughout application lifetime
        services.AddSingleton<ISingletonLifecycleService, SingletonLifecycleService>();

        // Tracker to demonstrate lifecycle differences inside the same request scope
        services.AddScoped<IDiLifecycleTracker, DiLifecycleTracker>();

        return services;
    }
}
