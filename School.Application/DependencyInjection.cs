using Microsoft.Extensions.DependencyInjection;
using School.Application.Interfaces.Service;
using School.Application.Service;

namespace School.Application.Injection;

public static class DependencyInjection {
    public static IServiceCollection AddSchoolApplication(this IServiceCollection service) {
        service.AddSingleton<SchoolService>();
        service.AddSingleton<ISchoolService, SchoolService>();

        return service;
    }
}
