using ASAPMethodology.Business.Abstract;
using ASAPMethodology.Core.Utilities.Results.Abstract;
using ASAPMethodology.Core.Utilities.Results.Concrete;
using ASAPMethodology.DataAccess.Abstract;
using ASAPMethodology.Entities.Concrete;
using ASAPMethodology.Entities.Dtos;
using AutoMapper;

namespace ASAPMethodology.Business.Concrete.Managers
{
    public class CostOfFutureManager : ICostOfFutureService
    {
        private readonly ICostOfFutureDal _costOfFutureDal;
        private readonly IMapper _mapper;

        public CostOfFutureManager(ICostOfFutureDal costOfFutureDal, IMapper mapper)
        {
            _costOfFutureDal = costOfFutureDal;
            _mapper = mapper;
        }

        public IResult Add(CostOfFutureAddDto costOfFutureAddDto)
        {
            var addedCostOfFuture = _mapper.Map<CostOfFuture>(costOfFutureAddDto);
            _costOfFutureDal.Add(addedCostOfFuture);
            return new SuccessResult("CostOfFuture added");
        }

        public List<DateTime> PolicyDate(DateTime startDate, DateTime endDate, int installementNo)
        {
            GetInstallementList(installementNo);
            List<DateTime> dateList = new List<DateTime>();
            var dateDiff = DateTime.Parse(endDate.ToString()) - DateTime.Parse(startDate.ToString());
            while (startDate == endDate)
            {
                dateList.Add(DateTime.Parse(dateDiff.ToString("dd-MM-yyyy")));
            }
            return dateList;
        }

        public List<int> DayList(DateTime startDate, DateTime endDate, int installementNo)
        {
            GetInstallementList(installementNo);
            List<int> days = new List<int>();
            var dateDiff = DateTime.Parse(endDate.ToString()) - DateTime.Parse(startDate.ToString());
            while (startDate == endDate)
            {
                days.Add(dateDiff.Days);
            }
            return days;
        }

        private static void GetInstallementList(int installementNo)
        {
            List<int> installementNoList = new List<int>();
            installementNoList.Add(installementNo);
        }

        public List<decimal> DailyPrice(decimal installementAmount, List<int> dayMonthNumbers)
        {
            List<decimal> dailyPrices = new List<decimal>();
            foreach (var dayMonthNumber in dayMonthNumbers)
            {
                dailyPrices.Add(installementAmount / 365 * dayMonthNumber);
            }
            return dailyPrices;
        }

        public List<decimal> MonthlyPrice(decimal installementAmount, List<int> dayMonthNumbers)
        {
            List<decimal> monthlyPrices = new List<decimal>();
            for (int i = 0; i < dayMonthNumbers.Count; i++)
            {
                monthlyPrices.Add(installementAmount / 12);
            }
            return monthlyPrices;
        }

        public IDataResult<CostOfFutureDto> GetByExpenseTypeName(string expenseTypeName)
        {
            var costOfFuture = new CostOfFutureDto { CostOfFuture = 
                _costOfFutureDal.Get(x => x.ExpenseType.Name == expenseTypeName, x => x.ExpenseType) };
            var costOfFutureMap = _mapper.Map<CostOfFutureDto>(costOfFuture);
            return new SuccessDataResult<CostOfFutureDto>(costOfFutureMap);
        }
    }
}
