using BaseArchitecture.Infrastructure.Shared.Interfaces;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.Shared.BaseService;
using Microsoft.Extensions.Localization;
using PhysiotherapistProject.Domain.Entities;
using PhysiotherapistProject.Infrastructure.RepositoryInterfaces;
using PhysiotherapistProject.Service.ServiceInterfaces;

namespace PhysiotherapistProject.Service.Service
{
    public class ClinicService : BaseService<Clinic>, IClinicService
    {
        #region Feilds
        private readonly IClinicRepository _clinicRepository;
        #endregion

        #region Constructor
        public ClinicService(IBaseRepository<Clinic> baseRepository,
                             IStringLocalizer<AppLocalization> stringLocalizer,
                             IClinicRepository clinicRepository) : base(baseRepository, stringLocalizer)
        {
            _clinicRepository = clinicRepository;
        }
        #endregion

        #region Methods
        #endregion

    }
}
