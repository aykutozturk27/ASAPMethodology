using ASAPMethodology.Business.Abstract;
using ASAPMethodology.Business.Concrete.Managers;
using ASAPMethodology.DataAccess.Abstract;
using ASAPMethodology.DataAccess.Concrete.EntityFramework;
using Autofac;

namespace ASAPMethodology.Business.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CostOfFutureManager>().As<ICostOfFutureService>();
            builder.RegisterType<EfCostOfFutureDal>().As<ICostOfFutureDal>();

            builder.RegisterType<ExpenseTypeManager>().As<IExpenseTypeService>();
            builder.RegisterType<EfExpenseTypeDal>().As<IExpenseTypeDal>();
        }
    }
}
