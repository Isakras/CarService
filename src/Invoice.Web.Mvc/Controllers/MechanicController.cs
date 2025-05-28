using Abp.AspNetCore.Mvc.Authorization;
using Invoice.Authorization;
using Invoice.Controllers;
using Invoice.Web.Models.Mechanic;
using Invoice.Workers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Invoice.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class MechanicController : InvoiceControllerBase
    {
        private readonly IMechanicAppService _mechanicAppService;
        public MechanicController(IMechanicAppService mechanicAppService)
        {
            _mechanicAppService = mechanicAppService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> GetMechanicById(long mechanicId)
        {
             var mechanic = await _mechanicAppService.GetMechanicByIdAsync(mechanicId);
             
             var model = new EditMechanicModalViewModel
             {
                 Mechanic = mechanic
             };

            return PartialView("_UpdateModal", model);

        }
    }
}
