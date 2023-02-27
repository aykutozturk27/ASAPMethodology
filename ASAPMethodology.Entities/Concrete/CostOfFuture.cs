using ASAPMethodology.Core.Entities;

namespace ASAPMethodology.Entities.Concrete
{
    public class CostOfFuture : BaseEntity
    {
        public string? CardName { get; set; }
        public string? CardLastName { get; set; }
        public int DocNum { get; set; }
        public int PolicyNum { get; set; }
        public DateTime PolicyBegDate { get; set; }
        public int InstallementNo { get; set; }
        public DateTime PolicyEndDate { get; set; }
        public string? Comments { get; set; }
        public string? Methodology { get; set; }

        public Guid ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }
    }
}
