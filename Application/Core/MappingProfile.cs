using AutoMapper;
using Domain.Entity.Active;

namespace Application.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Activity, Activity>();
        }
    }
}
