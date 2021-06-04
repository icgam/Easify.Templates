using AutoMapper;
using Easify.Template.Common;
using Easify.Template.Core.Shared.Domain;

namespace Easify.Template.Core.Shared.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Sample, SampleDto>();
        }
    }
}
