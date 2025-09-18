using BaseArchitecture.Infrastructure.Shared.Interfaces;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.Shared.BaseService;
using Microsoft.Extensions.Localization;
using PhysiotherapistProject.Domain.Entities;
using PhysiotherapistProject.Infrastructure.RepositoryInterfaces;
using PhysiotherapistProject.Service.ServiceInterfaces;

namespace PhysiotherapistProject.Service.Service
{
    public class ReportService : BaseService<Report>, IReportService
    {
        #region Feilds
        private readonly IReportRepository _reportRepository;
        #endregion

        #region Constructor
        public ReportService(IBaseRepository<Report> baseRepository,
                             IStringLocalizer<AppLocalization> stringLocalizer,
                             IReportRepository reportRepository) : base(baseRepository, stringLocalizer)
        {
            _reportRepository = reportRepository;
        }
        #endregion

        #region Methods
        #endregion

    }
}
