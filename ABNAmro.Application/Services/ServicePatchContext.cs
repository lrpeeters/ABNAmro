using System;
using Microsoft.AspNetCore.JsonPatch;

namespace ABNAmro.Application.Services
{
    public class ServicePatchContext<TPatchDto>
        where TPatchDto : class
    {
        public Guid Id { get; set; }
        public JsonPatchDocument<TPatchDto> Dto { get; set; }
    }
}
