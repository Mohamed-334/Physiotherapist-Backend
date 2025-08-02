using BaseArchitecture.Domain.Shared.BaseEntity;
using BaseArchitecture.Infrastructure.Shared.Interfaces;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.Shared.ExtensionMethods;
using BaseArchitecture.Service.Shared.Interface;
using BaseArchitecture.Service.Shared.PaginatedList;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace BaseArchitecture.Service.Shared.BaseService
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        #region Vars / Props

        protected readonly IBaseRepository<TEntity> _baseRepository;
        protected readonly IStringLocalizer<AppLocalization> _stringLocalizer;

        #endregion

        #region Constructor(s)
        public BaseService(IBaseRepository<TEntity> baseRepository, IStringLocalizer<AppLocalization> stringLocalizer)
        {
            _baseRepository = baseRepository;
            _stringLocalizer = stringLocalizer;
        }

        #endregion

        #region Actions
        public async virtual Task<List<TEntity>> GetAll()
        {
            var List = await _baseRepository
                            .GetTableAsTracking()
                            .ToListAsync();
            return List;
        }
        public async virtual Task<TEntity> GetById(int id)
        {
            var Entity = await _baseRepository
                            .GetByIdAsync(id);
            return Entity;
        }
        public async Task<string> AddAsync(TEntity entity)
        {
            await _baseRepository.AddAsync(entity);
            return _stringLocalizer[AppLocalizationKeys.Success];
        }
        public async Task<string> EditAsync(TEntity entity)
        {
            await _baseRepository.UpdateAsync(entity);
            return _stringLocalizer[AppLocalizationKeys.Success];
        }
        public async Task<string> HardDeleteAsync(TEntity entity)
        {
            var trans = _baseRepository.BeginTransaction();
            try
            {
                await _baseRepository.DeleteAsync(entity);
                await trans.CommitAsync();
                return _stringLocalizer[AppLocalizationKeys.Success];
            }
            catch
            {
                await trans.RollbackAsync();
                return _stringLocalizer[AppLocalizationKeys.DeletedFailed];
            }
        }
        public async Task<string> SoftDeleteAndActivationAsync(int id)
        {
            var entity = await _baseRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return _stringLocalizer[AppLocalizationKeys.NotFound];
            }
            entity.IsDeleted = !entity.IsDeleted;
            var trans = _baseRepository.BeginTransaction();
            try
            {
                await EditAsync(entity);
                await trans.CommitAsync();
                return _stringLocalizer[AppLocalizationKeys.Success];
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return _stringLocalizer[AppLocalizationKeys.DeletedFailed];
            }
        }
        public async virtual Task<PaginatedList<TEntity>> GetPaginatedList(int pageNumber = 1, int pageSize = 10)
        {
            var Queryable = _baseRepository
                            .GetTableNoTracking()
                            .AsQueryable();

            var PaginatedList = await Queryable
                .ToPaginatedListAsync(pageNumber, pageSize);
            return PaginatedList;
        }

        #endregion
    }
}
