using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.Application.Interfaces.Persistance;
using School.Infrastructure.Postgres.Dapper;
using School.Infrastructure.Postgres.EF;

namespace School.Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddSchoolInfrastructure(this IServiceCollection services, IConfiguration config) {
        services.Configure<DatabaseOption>(config.GetSection(DatabaseOption.SectionName));

        AddDapperServices(services);
        // AddEFServices(services);

        return services;
    }

    /// <summary>
    /// Call this method when you wish to leverage this project using only Entity Framework
    /// </summary>
    private static void AddEFServices(IServiceCollection services) {
        services.AddSingleton<SchoolRepositoryPostgresDbContext>();
    }

    /// <summary>
    /// Call this method when you wish to leverage this project using only Dapper
    /// </summary>
    private static void AddDapperServices(IServiceCollection services) {
        services.AddSingleton<SchoolRepositoryPostgresDapper>();
        services.AddScoped<ISchoolRepository, SchoolRepositoryPostgresDapper>();
    }
}
