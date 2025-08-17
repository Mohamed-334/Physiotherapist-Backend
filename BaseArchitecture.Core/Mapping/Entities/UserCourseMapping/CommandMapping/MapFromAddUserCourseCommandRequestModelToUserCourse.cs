using BaseArchitecture.Core.Mapping.Shared;
using PhysiotherapistProject.Core.Features.UserCourses.Commands.RequestModels;
using PhysiotherapistProject.Domain.Entities;

namespace PhysiotherapistProject.Core.Mapping.Entities.UserCourseMapping
{
    public partial class UserCourseMapping
    {
        public void MapFromAddUserCourseCommandRequestModelToUserCourse()
        {
            CreateMap<AddUserCourseCommandRequestModel, UserCourse>()
                .AfterMap<MetaMappingDataBasedOnDestination<AddUserCourseCommandRequestModel, UserCourse>>();
        }
    }
}
