using ASAPMethodology.Entities.Concrete;
using ASAPMethodology.Entities.Dtos;
using AutoMapper;

namespace ASAPMethodology.Business.Mappings.AutoMapper.Profiles
{
    public class CostOfFutureProfile : Profile
    {
        public CostOfFutureProfile()
        {
            CreateMap<CostOfFutureAddDto, CostOfFuture>();
        }
    }
}
