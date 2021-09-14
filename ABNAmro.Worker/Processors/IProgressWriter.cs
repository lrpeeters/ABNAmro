using System;
using System.Threading.Tasks;

namespace ABNAmro.Worker.Processors
{
    public interface IProgressWriter
    {
        Task WriteAsync(Guid calculationId, decimal percentageComplete, decimal calculationResult);
    }
}