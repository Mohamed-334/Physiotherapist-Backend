using BaseArchitecture.Service.Shared.Interface;
using PhysiotherapistProject.Domain.Entities;

namespace PhysiotherapistProject.Service.ServiceInterfaces
{
    public interface ICourseService : IBaseService<Course>
    {
        Task<bool> IsCourseNameExistAsync(string courseName, string CourseNameLocalization);
        Task<Course> CreateCourseName();
    }
}
