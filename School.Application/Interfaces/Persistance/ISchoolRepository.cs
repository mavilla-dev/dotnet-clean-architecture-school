using School.Core.Entities;

namespace School.Application.Interfaces.Persistance;

public interface ISchoolRepository
{
    public Task<SchoolEnt?> GetSchoolByIdAsync(int id);
    public Task<SchoolEnt> CreateSchoolAsync(string schoolName);
    public Task<IList<SchoolEnt>> SearchSchoolsAsync();
    Task DeleteSchoolByIdAsync(int id);
}
