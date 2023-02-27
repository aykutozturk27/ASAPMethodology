using ASAPMethodology.Core.Entities;
using ASAPMethodology.Entities.ComplexTypes;

namespace ASAPMethodology.Entities.Concrete
{
    public class ExpenseType : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<CostOfFuture> CostOfFutures { get; set; }
    }
}
