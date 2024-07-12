using School.Core.Entities;

namespace School.Application.Interfaces.Persistance;

public interface ISchoolRepository
{
    public Task<SchoolEnt?> GetSchoolById(int id);
    public Task<SchoolEnt> CreateSchool(string schoolName);
}
