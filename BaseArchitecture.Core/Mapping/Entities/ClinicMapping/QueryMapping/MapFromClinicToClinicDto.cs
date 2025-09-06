using BaseArchitecture.Core.Mapping.Shared;
using PhysiotherapistProject.Core.Features.Clinics.Dto;
using PhysiotherapistProject.Domain.Entities;

namespace PhysiotherapistProject.Core.Mapping.Entities.ClinicMapping
{
    public partial class ClinicMapping
    {
        public void MapFromClinicToClinicDto()
        {
            CreateMap<Clinic, ClinicDto>()
                .AfterMap<MetaMappingDataBasedOnSource<Clinic, ClinicDto>>();
        }
    }
}
