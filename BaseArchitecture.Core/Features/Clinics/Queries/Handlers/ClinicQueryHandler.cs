using AutoMapper;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.Shared.PaginatedList;
using MediatR;
using Microsoft.Extensions.Localization;
using PhysiotherapistProject.Core.Features.Clinics.Dto;
using PhysiotherapistProject.Core.Features.Clinics.Queries.RequestModels;
using PhysiotherapistProject.Service.ServiceInterfaces;

namespace PhysiotherapistProject.Core.Features.Clinics.Queries.Handlers
{
    public class ClinicQueryHandler : ResponseHandler, IRequestHandler<GetClinicByIdQueryRequestModel, Response<ClinicDto>>,
                                                       IRequestHandler<GetClinicListQueryRequestModel, Response<List<ClinicDto>>>,
                                                       IRequestHandler<GetClinicPaginatedListQueryRequestModel, Response<PaginatedList<ClinicDto>>>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly IClinicService _clinicService;
        #endregion

        #region Constructor
        public ClinicQueryHandler(IStringLocalizer<AppLocalization> stringLocalizer,
                                  IMapper mapper,
                                  IClinicService clinicService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _clinicService = clinicService;
        }

        #endregion

        #region Methods
        public async Task<Response<ClinicDto>> Handle(GetClinicByIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var Clinic = await _clinicService.GetByIdAsync(request.Id);
            if (Clinic == null)
                return NotFound<ClinicDto>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var ClinicDto = _mapper.Map<ClinicDto>(Clinic);
            return Success(ClinicDto, _stringLocalizer[AppLocalizationKeys.Success]);
        }

        public async Task<Response<List<ClinicDto>>> Handle(GetClinicListQueryRequestModel request, CancellationToken cancellationToken)
        {
            var Clinics = await _clinicService.GetAllAsync();
            if (Clinics == null)
                return NotFound<List<ClinicDto>>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var ClinicsDto = _mapper.Map<List<ClinicDto>>(Clinics);
            return Success(ClinicsDto, _stringLocalizer[AppLocalizationKeys.Success], new { TotalCount = ClinicsDto.Count });

        }

        public async Task<Response<PaginatedList<ClinicDto>>> Handle(GetClinicPaginatedListQueryRequestModel request, CancellationToken cancellationToken)
        {
            var PaginatedList = await _clinicService.GetPaginatedListAsync(request.PageNumber, request.PageSize);
            if (PaginatedList == null || PaginatedList.Data.Count == 0)
                return NotFound<PaginatedList<ClinicDto>>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var ClinicFullDataDtoList = _mapper.Map<List<ClinicDto>>(PaginatedList.Data);
            var paginatedListDto = PaginatedList<ClinicDto>.Success(ClinicFullDataDtoList, PaginatedList.TotalCount, PaginatedList.CurrentPage, PaginatedList.PageSize);
            return Success(paginatedListDto, _stringLocalizer[AppLocalizationKeys.Success]);
        }
        #endregion
    }
}
