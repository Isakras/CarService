using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Invoice.Controllers
{
    public abstract class InvoiceControllerBase : AbpController
    {
        protected InvoiceControllerBase()
        {
            LocalizationSourceName = InvoiceConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
