using ErrorOr;
using School.Core.Entities;

namespace School.Application.Interfaces.Service;

public interface ISchoolService {
    public Task<ErrorOr<SchoolEnt>> CreateSchoolAsync(string name);
    public Task<ErrorOr<int>> DeleteSchoolByIdAsync(int id);
    public Task<ErrorOr<SchoolEnt?>> GetSchoolByIdAsync(int id);
    public Task<ErrorOr<IList<SchoolEnt>>> SearchSchoolsAsync();
}
