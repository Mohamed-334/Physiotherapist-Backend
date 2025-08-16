using BaseArchitecture.Core.Mapping.Shared;
using PhysiotherapistProject.Core.Features.Courses.Commands.RequestModels;
using PhysiotherapistProject.Domain.Entities;

namespace PhysiotherapistProject.Core.Mapping.Entities.CourseMapping
{
    public partial class CourseMapping
    {
        public void MapFromUpdateCourseCommandRequestModelToCourse()
        {
            CreateMap<UpdateCourseCommandRequestModel, Course>()
                .AfterMap<MetaMappingDataBasedOnDestination<UpdateCourseCommandRequestModel, Course>>();
        }
    }
}
