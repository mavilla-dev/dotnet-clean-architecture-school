using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace School.RestApi.Endpoints;

public class ErrorsEndpoint : IEndpointDefinition {
    public void DefineEndpoints(WebApplication app) {
        app.MapGet("/errors", HandleError).ExcludeFromDescription();
    }

    private IResult HandleError() {
        return Results.Problem();
    }
}
