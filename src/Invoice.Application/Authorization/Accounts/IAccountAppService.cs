using Abp.Application.Services;
using Invoice.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace Invoice.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
