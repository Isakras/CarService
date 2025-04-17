using Abp.Application.Services;
using Invoice.Sessions.Dto;
using System.Threading.Tasks;

namespace Invoice.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
