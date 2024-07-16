using ErrorOr;
using School.Application.Interfaces.Persistance;
using School.Application.Interfaces.Service;
using School.Core.Entities;

namespace School.Application.Service;

public class SchoolService : ISchoolService {
    private readonly ISchoolRepository _schoolRepository;

    public SchoolService(ISchoolRepository schoolRepository) {
        _schoolRepository = schoolRepository;
    }

    public Task<ErrorOr<SchoolEnt>> CreateSchoolAsync(string name) {
        return _schoolRepository.CreateSchoolAsync(name);
    }

    public Task<ErrorOr<int>> DeleteSchoolByIdAsync(int id) {
        return _schoolRepository.DeleteSchoolByIdAsync(id);
    }

    public Task<ErrorOr<SchoolEnt?>> GetSchoolByIdAsync(int id) {
        return _schoolRepository.GetSchoolByIdAsync(id);
    }

    public Task<ErrorOr<IList<SchoolEnt>>> SearchSchoolsAsync() {
        return _schoolRepository.SearchSchoolsAsync();
    }
}
