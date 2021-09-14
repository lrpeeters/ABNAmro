using System;
using System.Threading.Tasks;
using ABNAmro.Application.Commands.Calculations;
using ABNAmro.Application.Commands.Progresses;
using ABNAmro.Application.Queries.Progresses;
using ABNAmro.CrossCutting.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABNAmro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private readonly ICreateCalculationCommand _createCalculationCommand;
        private readonly ICreateProgressCommand _createProgressCommand;
        private readonly IGetProgressByCalculationQuery _getProgressByCalculationQuery;

        public CalculationsController(ICreateCalculationCommand createCalculationCommand, ICreateProgressCommand createProgressCommand, IGetProgressByCalculationQuery getProgressByCalculationQuery)
        {
            _createCalculationCommand = createCalculationCommand.NullCheck(nameof(createCalculationCommand));
            _createProgressCommand = createProgressCommand.NullCheck(nameof(createProgressCommand));
            _getProgressByCalculationQuery = getProgressByCalculationQuery.NullCheck(nameof(getProgressByCalculationQuery));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCalculation calculationDto)
        {
            var id = await _createCalculationCommand.ExecuteAsync(calculationDto);
            return new ObjectResult(id)
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        [HttpGet("{id}/progress")]
        public async Task<IActionResult> GetProgress([FromRoute] Guid id)
        {
            var progressDto = await _getProgressByCalculationQuery.ExecuteAsync(id);
            return Ok(progressDto);
        }

        [HttpPost("{id}/progress")]
        public async Task<IActionResult> CreateProgress([FromRoute] CreateProgress progressDto)
        {
            var id = await _createProgressCommand.ExecuteAsync(progressDto);
            return new ObjectResult(id)
            {
                StatusCode = StatusCodes.Status201Created
            };
        }
    }
}
