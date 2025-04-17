using Abp.Modules;
using Abp.Reflection.Extensions;
using Invoice.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Invoice.Web.Host.Startup
{
    [DependsOn(
       typeof(InvoiceWebCoreModule))]
    public class InvoiceWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public InvoiceWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(InvoiceWebHostModule).GetAssembly());
        }
    }
}
