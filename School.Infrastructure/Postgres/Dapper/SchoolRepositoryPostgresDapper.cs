using Dapper;
using ErrorOr;
using Microsoft.Extensions.Options;
using Npgsql;
using School.Application.Interfaces.Persistance;
using School.Core.Entities;
using School.Core.Errors;

namespace School.Infrastructure.Postgres.Dapper;

public class SchoolRepositoryPostgresDapper : ISchoolRepository {
    private readonly DatabaseOption _option;

    public SchoolRepositoryPostgresDapper(IOptions<DatabaseOption> option) {
        _option = option.Value;
    }

    /// <inheritdoc />
    public async Task<ErrorOr<SchoolEnt>> CreateSchoolAsync(string schoolName) {
        try {
            using var conn = GetConnection();
            var values = new { Name = schoolName };
            return await conn.QuerySingleAsync<SchoolEnt>(
                "INSERT INTO school (name, create_time) values (@Name) RETURNING school.*",
                values);
        } catch (InvalidOperationException) {
            // TODO log e
            return Errors.School.InsertingNewSchool;
        }
    }

    /// <inheritdoc />
    public async Task<ErrorOr<int>> DeleteSchoolByIdAsync(int id) {
        using var conn = GetConnection();
        var rowsAffected = await conn.ExecuteAsync("delete from school where id = @schoolId", new { schoolId = id });
        return rowsAffected;
    }

    /// <inheritdoc />
    public async Task<ErrorOr<SchoolEnt?>> GetSchoolByIdAsync(int id) {
        try {
            using var conn = GetConnection();
            return await conn.QuerySingleOrDefaultAsync<SchoolEnt?>(
                "select * from school where school.id = @schoolId ",
                new { schoolId = id }
                );
        } catch (InvalidOperationException) {
            // More than 1 record was found
            // todo log e
            return Error.Conflict(description: "We matched multiple schools with the same ID");
        }
    }

    /// <inheritdoc />
    public async Task<ErrorOr<IList<SchoolEnt>>> SearchSchoolsAsync() {
        using var conn = GetConnection();
        return (await conn.QueryAsync<SchoolEnt>("select * from school order by name")).AsList();
    }

    // Consider using an interface to inject this into the class instead for
    // better unit testing
    private NpgsqlConnection GetConnection() {
        return new NpgsqlConnection(_option.Postgres.ConnectionString);
    }
}
