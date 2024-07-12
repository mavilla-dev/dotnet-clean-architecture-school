using School.Application.Interfaces.Persistance;
using School.Core.Entities;

namespace School.Infrastructure.Postgres.EF;

public class SchoolRepositoryPostgresDbContext : ISchoolRepository {
    public Task<SchoolEnt?> GetSchoolById(int id) {
        throw new NotImplementedException();
    }
}
