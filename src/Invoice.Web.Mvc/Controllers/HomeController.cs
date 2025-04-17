using Abp.AspNetCore.Mvc.Authorization;
using Invoice.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Web.Controllers;

[AbpMvcAuthorize]
public class HomeController : InvoiceControllerBase
{
    public ActionResult Index()
    {
        return View();
    }
}
