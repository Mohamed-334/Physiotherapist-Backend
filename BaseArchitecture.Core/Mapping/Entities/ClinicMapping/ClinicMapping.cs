using AutoMapper;

namespace PhysiotherapistProject.Core.Mapping.Entities.ClinicMapping
{
    public partial class ClinicMapping : Profile
    {
        public ClinicMapping()
        {
            MapFromClinicToClinicDto();
            MapFromAddClinicCommandRequestModelToClinic();
            MapFromUpdateClinicCommandRequestModelToClinic();
        }
    }
}
