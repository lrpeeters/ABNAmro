using System;

namespace ABNAmro.Application.Services
{
    public class ServiceUpdateContext<TDto>
    {
        public Guid Id { get; set; }
        public TDto Dto { get; set; }
    }
}
