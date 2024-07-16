using ErrorOr;

namespace School.Core.Errors;

public static class Errors {
    public static class School {
        public static Error InsertingNewSchool => Error.Unexpected(description: "Unable to insert school");
    }
}
