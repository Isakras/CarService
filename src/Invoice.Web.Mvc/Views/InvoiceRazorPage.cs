using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Invoice.Web.Views;

public abstract class InvoiceRazorPage<TModel> : AbpRazorPage<TModel>
{
    [RazorInject]
    public IAbpSession AbpSession { get; set; }

    protected InvoiceRazorPage()
    {
        LocalizationSourceName = InvoiceConsts.LocalizationSourceName;
    }
}
