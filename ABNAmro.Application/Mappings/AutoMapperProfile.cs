using ABNAmro.Application.Commands.Calculations;
using ABNAmro.Application.Commands.Progresses;
using ABNAmro.Application.Queries.Calculations;
using ABNAmro.Application.Queries.Progresses;
using ABNAmro.Domain.Calculations;
using ABNAmro.Domain.Progresses;
using AutoMapper;

namespace ABNAmro.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateCommandMappings();
            CreateQueryMappings();
        }

        private void CreateCommandMappings()
        {
            CreateMap<CreateCalculation, Calculation>()
                .ReverseMap();
            CreateMap<CreateProgress, Progress>()
                .ReverseMap();
        }

        private void CreateQueryMappings()
        {
            CreateMap<GetProgress, Progress>()
                .ReverseMap();
            CreateMap<GetCalculation, Calculation>()
                .ReverseMap();
        }
    }
}
