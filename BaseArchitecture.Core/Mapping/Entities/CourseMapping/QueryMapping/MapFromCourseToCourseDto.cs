using BaseArchitecture.Core.Mapping.Shared;
using PhysiotherapistProject.Core.Features.Courses.Dto;
using PhysiotherapistProject.Domain.Entities;

namespace PhysiotherapistProject.Core.Mapping.Entities.CourseMapping
{
    public partial class CourseMapping
    {
        public void MapFromCourseToCourseDto()
        {
            CreateMap<Course, CourseDto>()
                .AfterMap<MetaMappingDataBasedOnSource<Course, CourseDto>>();
        }
    }
}
