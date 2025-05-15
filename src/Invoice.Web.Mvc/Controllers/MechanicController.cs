using Invoice.Controllers;
using Invoice.Workers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Invoice.Web.Controllers
{
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
    }
}
