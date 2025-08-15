using BaseArchitecture.Domain.Shared.BaseEntity.Interfaces;

namespace BaseArchitecture.Domain.Shared.BaseEntity.Implementations
{
    public class BaseEntityWithName : BaseEntity, IBaseEntityWithName
    {
        public string? Name { get; set; }
        public string? NameLocalization { get; set; }
    }
}
