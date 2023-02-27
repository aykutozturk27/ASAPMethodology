using ASAPMethodology.Entities.Concrete;

namespace ASAPMethodology.MvcWebUI.Models
{
    public class CostOfFutureModel
    {
        public List<DateTime> PolicyDates { get; set; }
        public List<int> Days { get; set; }
        public List<decimal> DailyPrices { get; set; }
        public List<decimal> MonthlyPrices { get; set; }
        public CostOfFuture CostOfFuture { get; set; }
    }
}
