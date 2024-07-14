using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;
using School.Application.Interfaces.Service;
using School.Application.Service;
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
        var schools = await service.SearchSchoolsAsync();
        return schools.Count == 0
            ? Results.NoContent()
            : Results.Ok(schools);
    }

    private async Task<IResult> GetSchoolByIdAsync(
        ISchoolService service,
        int id) {
        var school = await service.GetSchoolByIdAsync(id);
        return school != null
            ? Results.Ok(school)
            : Results.NotFound();
    }

    private async Task<IResult> DeleteSchoolByIdAsync(
        ISchoolService service,
        int id) {
        await service.DeleteSchoolByIdAsync(id);
        return Results.Ok();
    }

    private async Task<IResult> CreateSchoolAsync(
        ISchoolService service,
        NewSchoolRequest newSchool) {
        return Results.Ok(await service.CreateSchoolAsync(newSchool.Name));
    }
}

public record NewSchoolRequest(string Name);
