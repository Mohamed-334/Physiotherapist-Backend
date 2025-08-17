using AutoMapper;

namespace PhysiotherapistProject.Core.Mapping.Entities.UserCourseMapping
{
    public partial class UserCourseMapping : Profile
    {
        public UserCourseMapping()
        {
            MapFromUserCourseToUserCourseDto();
            MapFromAddUserCourseCommandRequestModelToUserCourse();
            MapFromUpdateUserCourseCommandRequestModelToUserCourse();
        }
    }
}
