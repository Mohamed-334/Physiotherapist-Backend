using BaseArchitecture.Core.Mapping.Shared;
using PhysiotherapistProject.Core.Features.Clinics.Commands.RequestModels;
using PhysiotherapistProject.Domain.Entities;

namespace PhysiotherapistProject.Core.Mapping.Entities.ClinicMapping
{
    public partial class ClinicMapping
    {
        public void MapFromAddClinicCommandRequestModelToClinic()
        {
            CreateMap<AddClinicCommandRequestModel, Clinic>()
                .AfterMap<MetaMappingDataBasedOnDestination<AddClinicCommandRequestModel, Clinic>>();
        }
    }
}
