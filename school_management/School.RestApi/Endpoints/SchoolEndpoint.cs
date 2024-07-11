namespace School.RestApi.Endpoints;

public class SchoolEndpoint : IEndpointDefinition {
    private List<School> _schools = [];

    public void DefineEndpoints(WebApplication app) {
        var schools = app.MapGroup("/schools");

        schools.MapGet("/", GetSchools);
        schools.MapPost("/", CreateSchool);
        schools.MapGet("/{id}", GetSchoolById);
        schools.MapDelete("/{id}", DeleteSchoolById);
    }

    private IResult GetSchools() {
        if (_schools.Count == 0) {
            return TypedResults.NoContent();
        }
        return TypedResults.Ok(_schools);
    }

    private IResult GetSchoolById(int id) {
        var school = _schools.FirstOrDefault(x => x.Id == id);
        return school != null
            ? Results.Ok(school)
            : Results.NotFound();
    }

    private IResult DeleteSchoolById(int id) {
        return Results.Ok();
    }

    private IResult CreateSchool(NewSchoolRequest newSchool) {
        if (newSchool == null || newSchool.Name.Trim().Length <= 5) {
            return Results.BadRequest("Name needs to be longer than 5 characters");
        }

        var school = new School(_schools.Count, newSchool.Name);
        _schools.Add(school);

        return TypedResults.Ok(school);
    }
}

public record NewSchoolRequest(string Name);

public record School(int Id, string Name);
