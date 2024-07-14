using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using School.Application.Interfaces.Persistance;
using School.Core.Entities;

namespace School.Infrastructure.Postgres.Dapper;

public class SchoolRepositoryPostgresDapper : ISchoolRepository {
    private readonly DatabaseOption _option;

    public SchoolRepositoryPostgresDapper(IOptions<DatabaseOption> option) {
        _option = option.Value;
    }

    public async Task<SchoolEnt> CreateSchoolAsync(string schoolName) {
        using var conn = new NpgsqlConnection(_option.Postgres.ConnectionString);
        var values = new { Name = schoolName };
        return await conn.QuerySingleAsync<SchoolEnt>(
            "INSERT INTO school (name, create_time) values (@Name) RETURNING school.*",
            values);
    }

    public async Task DeleteSchoolByIdAsync(int id) {
        using var conn = new NpgsqlConnection(_option.Postgres.ConnectionString);
        await conn.ExecuteAsync("delete from school where id = @schoolId", new { schoolId = id });
    }

    public async Task<SchoolEnt?> GetSchoolByIdAsync(int id) {
        try {
            using var conn = new NpgsqlConnection(_option.Postgres.ConnectionString);
            return await conn.QuerySingleOrDefaultAsync<SchoolEnt?>(
                "select * from school where school.id = @schoolId ",
                new { schoolId = id }
                );
        } catch (InvalidOperationException) {
            // More than 1 record was found
            // todo log e
            return null;
        }
    }

    public async Task<IList<SchoolEnt>> SearchSchoolsAsync() {
        using var conn = new NpgsqlConnection(_option.Postgres.ConnectionString);
        return (await conn.QueryAsync<SchoolEnt>("select * from school order by name")).AsList();
    }
}
