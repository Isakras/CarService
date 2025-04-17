using Abp.Authorization;
using Abp.Runtime.Session;
using Invoice.Configuration.Dto;
using System.Threading.Tasks;

namespace Invoice.Configuration;

[AbpAuthorize]
public class ConfigurationAppService : InvoiceAppServiceBase, IConfigurationAppService
{
    public async Task ChangeUiTheme(ChangeUiThemeInput input)
    {
        await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
    }
}
