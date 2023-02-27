using ASAPMethodology.Business.ValidationRules.FluentValidation;
using ASAPMethodology.Entities.Dtos;
using Autofac;
using FluentValidation;

namespace ASAPMethodology.Business.DependencyResolvers.Autofac
{
    public class ValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CostOfFutureValidator>().As<IValidator<CostOfFutureAddDto>>().SingleInstance();
        }
    }
}
