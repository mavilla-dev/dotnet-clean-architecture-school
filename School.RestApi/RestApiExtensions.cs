using School.RestApi.Endpoints;

namespace School.RestApi;

public static class RestApiExtensions {
    public static void AddSchoolEndpoints(this IServiceCollection services) {
        var definitions = new List<IEndpointDefinition>();
        var interfaceType = typeof(IEndpointDefinition);

        var types = interfaceType.Assembly.GetExportedTypes()
            .Where(x => x.IsClass && !x.IsAbstract && x.GetInterface(interfaceType.Name) != null);

        foreach (var type in types) {
            services.AddSingleton(type, type);
            services.AddSingleton(interfaceType, type);
        }
    }

    public static void MapSchoolEndpointDefinitions(this WebApplication app) {
        var definitions = app.Services.GetServices<IEndpointDefinition>();
        foreach (var def in definitions) {
            def.DefineEndpoints(app);
        }
    }
}
