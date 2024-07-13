using Microsoft.Extensions.DependencyInjection;
using School.Application.Service;

namespace School.Application;

public static class DependencyInjection {
    public static IServiceCollection AddSchoolApplication(this IServiceCollection service) {
        service.AddSingleton<SchoolService>();
        service.AddScoped<ISchoolService, SchoolService>();

        return service;
    }
}
