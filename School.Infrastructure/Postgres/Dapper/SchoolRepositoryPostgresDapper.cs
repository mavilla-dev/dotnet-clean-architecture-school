using Dapper;
using Npgsql;
using School.Application.Interfaces.Persistance;
using School.Core.Entities;

namespace School.Infrastructure.Postgres.Dapper;

public class SchoolRepositoryPostgresDapper : ISchoolRepository {
    private readonly DatabaseOption _option;

    public SchoolRepositoryPostgresDapper(DatabaseOption option) {
        _option = option;
    }

    public async Task<SchoolEnt> CreateSchool(string schoolName) {
        using var conn = new NpgsqlConnection(_option.Postgres.ConnectionString);
        var values = new { Name = schoolName, CreateTime = DateTime.Now };
        await conn.ExecuteAsync(
            "INSERT INTO school (name, create_time) values (@Name, @CreateTime)",
            values);
    }

    public async Task<SchoolEnt?> GetSchoolById(int id) {
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
}
