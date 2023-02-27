using ASAPMethodology.Core.Utilities.Results.Abstract;
using ASAPMethodology.Entities.Dtos;

namespace ASAPMethodology.Business.Abstract
{
    public interface ICostOfFutureService
    {
        IDataResult<CostOfFutureDto> GetByExpenseTypeName(string expenseTypeName);
        IResult Add(CostOfFutureAddDto costOfFutureAddDto);
        List<DateTime> PolicyDate(DateTime startDate, DateTime endDate, int installementNo);
        List<int> DayList(DateTime startDate, DateTime endDate, int installementNo);
        List<decimal> DailyPrice(decimal installementAmount, List<int> dayMonthNumbers);
        List<decimal> MonthlyPrice(decimal installementAmount, List<int> dayMonthNumbers);
    }
}
