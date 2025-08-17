using BaseArchitecture.Infrastructure.Shared.Interfaces;
using PhysiotherapistProject.Domain.Entities;

namespace PhysiotherapistProject.Infrastructure.RepositoryInterfaces
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        Task<bool> IsCourseNameExistAsync(string courseName, string CourseNameLocalization);
    }
}
