using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Invoice.Authorization;

namespace Invoice;

[DependsOn(
    typeof(InvoiceCoreModule),
    typeof(AbpAutoMapperModule))]
public class InvoiceApplicationModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Authorization.Providers.Add<InvoiceAuthorizationProvider>();
    }

    public override void Initialize()
    {
        var thisAssembly = typeof(InvoiceApplicationModule).GetAssembly();

        IocManager.RegisterAssemblyByConvention(thisAssembly);

        Configuration.Modules.AbpAutoMapper().Configurators.Add(
            // Scan the assembly for classes which inherit from AutoMapper.Profile
            cfg => cfg.AddMaps(thisAssembly)
        );
    }
}
