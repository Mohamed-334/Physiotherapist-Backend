using BaseArchitecture.Core.Mapping.Shared;
using PhysiotherapistProject.Core.Features.UserCourses.Dto;
using PhysiotherapistProject.Domain.Entities;

namespace PhysiotherapistProject.Core.Mapping.Entities.UserCourseMapping
{
    public partial class UserCourseMapping
    {
        public void MapFromUserCourseToUserCourseDto()
        {
            CreateMap<UserCourse, UserCourseDto>()
                .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course.GetLocalizedName() ?? ""))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User.GetLocalizedName() ?? ""))
                .AfterMap<MetaMappingDataBasedOnSource<UserCourse, UserCourseDto>>();
        }
    }
}
