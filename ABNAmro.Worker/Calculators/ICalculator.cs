using System.Threading.Tasks;
using ABNAmro.Application.Queries.Calculations;

namespace ABNAmro.Worker.Calculators
{
    interface ICalculator
    {
        void Calculate(GetCalculation calculation);
    }
}
