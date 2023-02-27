using ASAPMethodology.Business.Abstract;
using ASAPMethodology.Core.Utilities.Results.Abstract;
using ASAPMethodology.Entities.ComplexTypes;
using ASAPMethodology.Entities.Concrete;
using ASAPMethodology.Entities.Dtos;
using ASAPMethodology.MvcWebUI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASAPMethodology.MvcWebUI.Controllers
{
    public class CostOfFutureController : Controller
    {
        private readonly ICostOfFutureService _costOfFutureService;
        private readonly IMapper _mapper;
        private CostOfFutureAddDto _addedCostOfFuture;
        private List<int> _dayMonthNumbers;

        public CostOfFutureController(ICostOfFutureService costOfFutureService, IMapper mapper)
        {
            _costOfFutureService = costOfFutureService;
            _mapper = mapper;
            _addedCostOfFuture = new CostOfFutureAddDto();
            _dayMonthNumbers = new List<int>();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new CostOfFutureAddDto
            {
                ExpenseTypeEnums = Enum.GetValues(typeof(ExpenseTypeEnum)).Cast<ExpenseTypeEnum>().ToList(),
                MethodologyTypes = Enum.GetValues(typeof(MethodologyType)).Cast<MethodologyType>().ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(CostOfFutureAddDto costOfFutureAddDto)
        {
            costOfFutureAddDto.ExpenseTypeEnums = Enum.GetValues(typeof(ExpenseTypeEnum)).Cast<ExpenseTypeEnum>().ToList();
            costOfFutureAddDto.MethodologyTypes = Enum.GetValues(typeof(MethodologyType)).Cast<MethodologyType>().ToList();

            if (ModelState.IsValid)
            {
                var type = costOfFutureAddDto.ExpenseType.ToString()?.Split(",");
                IDataResult<CostOfFutureDto> expenseType = null;
                foreach (var item in type)
                {
                    expenseType = _costOfFutureService.GetByExpenseTypeName(item);
                    if (expenseType == null)
                    {
                        ModelState.AddModelError("Expense type", "Expense Type is not null");
                        return View(costOfFutureAddDto);
                    }
                }
                var mappedExpenseTypeId = _mapper.Map<CostOfFuture>(expenseType);
                var methodologyList = costOfFutureAddDto.MethodologyRadioOptions.ToString()?.Split(",");

                var dayNumbersCount = _dayMonthNumbers.Count(x => x < costOfFutureAddDto.InstallementNo);
                
                _dayMonthNumbers.Add(costOfFutureAddDto.InstallementNo);

                CostOfFuture costOfFuture = new()
                {
                    ExpenseTypeId = mappedExpenseTypeId.Id,
                    CardName = costOfFutureAddDto.CardName,
                    CardLastName = costOfFutureAddDto.CardLastName,
                    DocNum = costOfFutureAddDto.DocNum,
                    PolicyNum = costOfFutureAddDto.PolicyNum,
                    PolicyBegDate = costOfFutureAddDto.PolicyBegDate,
                    InstallementNo = costOfFutureAddDto.InstallementNo,
                    PolicyEndDate = costOfFutureAddDto.PolicyEndDate,
                    Comments = costOfFutureAddDto.Comments,
                    Methodology = methodologyList?.ToString(),
                    InstallementAmount = costOfFutureAddDto.InstallementAmount
                };

                var costOfFutureMap = _mapper.Map<CostOfFutureAddDto>(costOfFuture);
                var result = _costOfFutureService.Add(costOfFutureMap);
                if (result.Success)
                {
                    return RedirectToAction("CalculateList");
                }
                else
                {
                    return View(costOfFutureAddDto);
                }
            }
            return View(costOfFutureAddDto);
        }

        [HttpGet]
        public IActionResult CalculateList()
        {
            var model = new CostOfFutureModel
            {
                Days = _costOfFutureService.DayList(_addedCostOfFuture.PolicyBegDate, _addedCostOfFuture.PolicyEndDate, 
                    _addedCostOfFuture.InstallementNo),
                PolicyDates = _costOfFutureService.PolicyDate(_addedCostOfFuture.PolicyBegDate, _addedCostOfFuture.PolicyEndDate,
                    _addedCostOfFuture.InstallementNo),
                DailyPrices = _costOfFutureService.DailyPrice(_addedCostOfFuture.InstallementAmount, null),
                MonthlyPrices = _costOfFutureService.MonthlyPrice(_addedCostOfFuture.InstallementAmount, null),
            };
            return View(model);
        }
    }
}
