using BaseArchitecture.Domain.Shared.BaseEntity.Implementations;
namespace PhysiotherapistProject.Domain.Entities
{
    public class Report : BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }

    }
}
