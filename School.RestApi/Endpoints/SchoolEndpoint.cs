using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using School.Application.Interfaces.Service;
using School.Core.Entities;

namespace School.RestApi.Endpoints;

public class SchoolEndpoint : IEndpointDefinition {
    public void DefineEndpoints(WebApplication app) {
        var schools = app.MapGroup("/schools");

        schools.MapGet("/", GetSchoolsAsync).Produces<SchoolEnt[]>();
        schools.MapPost("/", CreateSchoolAsync).Produces<SchoolEnt>();

        schools.MapGet("/{id}", GetSchoolByIdAsync).Produces<SchoolEnt>();
        schools.MapDelete("/{id}", DeleteSchoolByIdAsync);
    }

    private async Task<IResult> GetSchoolsAsync(ISchoolService service) {
        var searchResult = await service.SearchSchoolsAsync();
        return searchResult.MatchFirst(
            value => Results.Ok(value),
            firstError => Results.Problem(title: firstError.Description));
    }

    private async Task<IResult> GetSchoolByIdAsync(ISchoolService service, int id) {
        var schoolResult = await service.GetSchoolByIdAsync(id);
        return schoolResult.MatchFirst(
            value => Results.Ok(value),
            firstError => Results.Problem(detail: firstError.Description));
    }

    private async Task<IResult> DeleteSchoolByIdAsync(ISchoolService service, int id) {
        var response = await service.DeleteSchoolByIdAsync(id);
        return response.MatchFirst(
            value => Results.Ok(value),
            firstError => Results.Problem(detail: firstError.Description)
        );
    }

    private async Task<IResult> CreateSchoolAsync(ISchoolService service, NewSchoolRequest newSchool) {
        return Results.Ok(await service.CreateSchoolAsync(newSchool.Name));
    }
}

public record NewSchoolRequest(string Name);
