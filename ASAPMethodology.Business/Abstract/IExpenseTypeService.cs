using ASAPMethodology.Entities.Concrete;

namespace ASAPMethodology.Business.Abstract
{
    public interface IExpenseTypeService
    {
        List<ExpenseType> GetAll();
    }
}
