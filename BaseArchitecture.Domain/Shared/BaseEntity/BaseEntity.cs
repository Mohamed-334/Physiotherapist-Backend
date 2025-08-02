namespace BaseArchitecture.Domain.Shared.BaseEntity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string? CreatorName { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        public string? ModifierName { get; set; }
        public DateTime? ModificationDate { get; set; } = DateTime.Now;
    }
}
