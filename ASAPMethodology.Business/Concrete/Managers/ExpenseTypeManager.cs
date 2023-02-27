using ASAPMethodology.Business.Abstract;
using ASAPMethodology.DataAccess.Abstract;
using ASAPMethodology.Entities.Concrete;

namespace ASAPMethodology.Business.Concrete.Managers
{
    public class ExpenseTypeManager : IExpenseTypeService
    {
        private readonly IExpenseTypeDal _expenseTypeDal;

        public ExpenseTypeManager(IExpenseTypeDal expenseTypeDal)
        {
            _expenseTypeDal = expenseTypeDal;
        }

        public List<ExpenseType> GetAll()
        {
            return _expenseTypeDal.GetList();
        }
    }
}
