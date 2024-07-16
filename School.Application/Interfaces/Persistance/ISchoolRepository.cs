using ErrorOr;
using School.Core.Entities;

namespace School.Application.Interfaces.Persistance;

public interface ISchoolRepository
{
    /// <summary>
    /// Inserts a new school record into the database
    /// </summary>
    public Task<ErrorOr<SchoolEnt>> CreateSchoolAsync(string schoolName);
    /// <summary>
    /// Deletes school by ID
    /// </summary>
    /// <returns>Number of records modified</returns>
    public Task<ErrorOr<int>> DeleteSchoolByIdAsync(int id);
    /// <summary>
    /// Returns information on a school based on ID if they exists. Null is returned
    /// if no match is found. If multiple schools match ID, ErrorOr is returned.
    /// </summary>
    /// <returns></returns>
    public Task<ErrorOr<SchoolEnt?>> GetSchoolByIdAsync(int id);
    /// <summary>
    /// Returns list of schools that match parameters
    /// </summary>
    public Task<ErrorOr<IList<SchoolEnt>>> SearchSchoolsAsync();
}
