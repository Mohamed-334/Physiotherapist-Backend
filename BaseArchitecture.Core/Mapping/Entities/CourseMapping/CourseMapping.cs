using AutoMapper;

namespace PhysiotherapistProject.Core.Mapping.Entities.CourseMapping
{
    public partial class CourseMapping : Profile
    {
        public CourseMapping()
        {
            MapFromCourseToCourseDto();
            MapFromAddCourseCommandRequestModelToCourse();
            MapFromUpdateCourseCommandRequestModelToCourse();
        }
    }
}
