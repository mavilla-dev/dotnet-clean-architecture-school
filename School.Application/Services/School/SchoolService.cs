using School.Core.Entities;

namespace School.Application.Service;

record CreateSchoolResult();

public interface ISchoolService {
    public Task<SchoolEnt> CreateSchool();
    public Task<SchoolEnt[]> SearchSchools();
}

public class SchoolService : ISchoolService {
    public Task<SchoolEnt> CreateSchool() {
        throw new NotImplementedException();
    }

    public Task<SchoolEnt[]> SearchSchools() {
        throw new NotImplementedException();
    }
}
