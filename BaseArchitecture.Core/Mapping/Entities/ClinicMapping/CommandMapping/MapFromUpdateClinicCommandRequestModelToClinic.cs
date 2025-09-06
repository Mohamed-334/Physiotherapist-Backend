using BaseArchitecture.Core.Mapping.Shared;
using PhysiotherapistProject.Core.Features.Clinics.Commands.RequestModels;
using PhysiotherapistProject.Domain.Entities;

namespace PhysiotherapistProject.Core.Mapping.Entities.ClinicMapping
{
    public partial class ClinicMapping
    {
        public void MapFromUpdateClinicCommandRequestModelToClinic()
        {
            CreateMap<UpdateClinicCommandRequestModel, Clinic>()
                .AfterMap<MetaMappingDataBasedOnDestination<UpdateClinicCommandRequestModel, Clinic>>();
        }
    }
}
