using ErrorOr;
using Microsoft.AspNetCore.Http;

namespace School.RestApi.Errors;

public static class ErrorMapper {
    public static IResult ErrorToProblem(this IResultExtensions results, Error err) {
        var statusCode = GetStatusCodeByError(err);
        return Results.Problem(detail: err.Description, statusCode: statusCode);
    }

    private static int GetStatusCodeByError(Error err) {
        return err.Type switch {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Failure => StatusCodes.Status500InternalServerError,
            ErrorType.Forbidden => StatusCodes.Status403Forbidden,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorType.Unexpected => StatusCodes.Status500InternalServerError,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError,
        };
    }
}
