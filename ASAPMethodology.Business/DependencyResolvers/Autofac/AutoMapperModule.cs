using ASAPMethodology.Business.Mappings.AutoMapper.Profiles;
using Autofac;
using AutoMapper;

namespace ASAPMethodology.Business.DependencyResolvers.Autofac
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(CreateConfiguration().CreateMapper()).As<IMapper>();
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CostOfFutureProfile());
            });

            return config;
        }
    }
}
