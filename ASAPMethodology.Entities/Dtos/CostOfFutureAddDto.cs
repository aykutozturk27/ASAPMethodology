using ASAPMethodology.Core.Entities;
using ASAPMethodology.Entities.ComplexTypes;

namespace ASAPMethodology.Entities.Dtos
{
    public class CostOfFutureAddDto : IDto
    {
        public List<DateTime>? PolicyDates { get; set; }
        public List<int>? Days { get; set; }
        public List<decimal>? DailyPrices { get; set; }
        public List<decimal>? MonthlyPrices { get; set; }
        public List<ExpenseTypeEnum>? ExpenseTypeEnums { get; set; }
        public List<MethodologyType>? MethodologyTypes { get; set; }
        public string? CardName { get; set; }
        public string? CardLastName { get; set; }
        public int DocNum { get; set; }
        public int PolicyNum { get; set; }
        public DateTime PolicyBegDate { get; set; }
        public int InstallementNo { get; set; }
        public DateTime PolicyEndDate { get; set; }
        public string? Comments { get; set; }
        public string? Methodology { get; set; }
        public bool IsSelected { get; set; }
        public List<string> ExpenseType { get; set; }
        public List<string> MethodologyRadioOptions { get; set; }
        public Guid ExpenseTypeId { get; set; }
    }
}
