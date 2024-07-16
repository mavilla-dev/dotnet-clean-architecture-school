using ErrorOr;

namespace School.Core.Errors;

public static class Errors {
    public static class School {
        public static Error InsertingNewSchool => Error.Unexpected(
            code: "Errors.School.Inserting.InsertingNewSchool",
            description: "Unable to insert school");
    }
}
