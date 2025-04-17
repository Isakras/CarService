using Invoice.Configuration.Dto;
using System.Threading.Tasks;

namespace Invoice.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
