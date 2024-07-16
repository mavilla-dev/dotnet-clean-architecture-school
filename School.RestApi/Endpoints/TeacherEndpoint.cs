using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace School.RestApi.Endpoints;

public class TeacherEndpoint : IEndpointDefinition {
    public void DefineEndpoints(WebApplication app) {
        var schools = app.MapGroup("/teachers");

        schools.MapGet("/", GetTeachers);
    }

    private IResult GetTeachers() {
        return Results.Ok();
    }
}
