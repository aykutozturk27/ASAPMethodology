namespace ASAPMethodology.Core.Entities
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
