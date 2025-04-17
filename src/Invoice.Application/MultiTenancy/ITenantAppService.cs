using Abp.Application.Services;
using Invoice.MultiTenancy.Dto;

namespace Invoice.MultiTenancy;

public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
{
}

