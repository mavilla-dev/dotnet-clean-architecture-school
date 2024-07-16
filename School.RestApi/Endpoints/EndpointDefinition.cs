using Microsoft.AspNetCore.Builder;

namespace School.RestApi.Endpoints;

public interface IEndpointDefinition {
    void DefineEndpoints(WebApplication app);
}
