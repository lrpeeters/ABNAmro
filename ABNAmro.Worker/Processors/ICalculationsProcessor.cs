using System.Threading.Tasks;

namespace ABNAmro.Worker.Processors
{
    internal interface ICalculationsProcessor
    {
        Task ExecuteAsync();
    }
}