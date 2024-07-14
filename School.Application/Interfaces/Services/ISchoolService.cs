using School.Core.Entities;

namespace School.Application.Interfaces.Service;

public interface ISchoolService {
    public Task<SchoolEnt> CreateSchoolAsync(string name);
    public Task<SchoolEnt?> GetSchoolByIdAsync(int id);
    public Task<IList<SchoolEnt>> SearchSchoolsAsync();
}
