using System.Threading.Tasks;
using ABNAmro.Application.Commands.Users;
using ABNAmro.Application.Queries.Users;
using ABNAmro.Application.Services.Security;
using ABNAmro.Domain.Users;

namespace ABNAmro.Application.Services
{
    public interface IUsersService : IReadWriteService<GetUser, CreateUser, UpdatePassword, PatchUser, User>
    {
        Task<ServiceResponse> Verify(VerifyUserContext context);
    }
}