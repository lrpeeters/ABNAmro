using System;

namespace ABNAmro.Application.Queries.Progresses
{
    public class GetProgress
    {
        public Guid Id { get; set; }

        public decimal Percentage { get; set; }

        public decimal CalculationResult { get; set; }
    }
}
