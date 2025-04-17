using Abp.AspNetCore.Mvc.ViewComponents;

namespace Invoice.Web.Views;

public abstract class InvoiceViewComponent : AbpViewComponent
{
    protected InvoiceViewComponent()
    {
        LocalizationSourceName = InvoiceConsts.LocalizationSourceName;
    }
}
