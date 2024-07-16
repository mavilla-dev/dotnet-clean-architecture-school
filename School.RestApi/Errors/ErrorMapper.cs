using ErrorOr;
using Microsoft.AspNetCore.Http;
using School.Core.Errors;
namespace School.RestApi.Errors;

public static class ErrorMapper
{
    public static int MapError(Error err) => err switch
    {
        _ => StatusCodes.Status500InternalServerError,
    };

    public static IResult ErrorToProblem(this IResultExtensions results, Error err)
    {
        return Results.Problem();
    }
}
