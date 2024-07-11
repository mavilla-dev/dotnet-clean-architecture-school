
namespace School.RestApi.Endpoints;

public static class Students {
    public static IEndpointRouteBuilder MapStudentEndpoint(this IEndpointRouteBuilder app) {
        app.MapGroup("/students")
            .MapGet("/", GetStudents);

        return app;
    }

    private static async Task GetStudents(HttpContext context) {
        await Task.CompletedTask;
    }
}
