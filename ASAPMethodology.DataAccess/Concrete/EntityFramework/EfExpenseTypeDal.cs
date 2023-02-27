using ASAPMethodology.Core.DataAccess.EntityFramework;
using ASAPMethodology.DataAccess.Abstract;
using ASAPMethodology.DataAccess.Concrete.EntityFramework.Contexts;
using ASAPMethodology.Entities.Concrete;

namespace ASAPMethodology.DataAccess.Concrete.EntityFramework
{
    public class EfExpenseTypeDal : EfEntityRepositoryBase<ExpenseType, ProjectDbContext>, IExpenseTypeDal
    {
    }
}
