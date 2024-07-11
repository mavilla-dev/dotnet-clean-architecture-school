using Microsoft.Extensions.DependencyInjection;

namespace Todo.Infra.Postgress.Dapper;

public static class DapperInjection {
    public static void SetupPostgressDapperDI(this IServiceCollection collection) {
        collection.AddTransient<DapperPostgressRepository>();
    }
}
