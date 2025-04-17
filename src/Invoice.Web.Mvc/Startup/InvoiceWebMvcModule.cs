using Abp.Modules;
using Abp.Reflection.Extensions;
using Invoice.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Invoice.Web.Startup;

[DependsOn(typeof(InvoiceWebCoreModule))]
public class InvoiceWebMvcModule : AbpModule
{
    private readonly IWebHostEnvironment _env;
    private readonly IConfigurationRoot _appConfiguration;

    public InvoiceWebMvcModule(IWebHostEnvironment env)
    {
        _env = env;
        _appConfiguration = env.GetAppConfiguration();
    }

    public override void PreInitialize()
    {
        Configuration.Navigation.Providers.Add<InvoiceNavigationProvider>();
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(InvoiceWebMvcModule).GetAssembly());
    }
}
