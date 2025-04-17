using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Invoice.Configuration;
using Invoice.EntityFrameworkCore;
using Invoice.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace Invoice.Migrator;

[DependsOn(typeof(InvoiceEntityFrameworkModule))]
public class InvoiceMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public InvoiceMigratorModule(InvoiceEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(InvoiceMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            InvoiceConsts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(InvoiceMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
