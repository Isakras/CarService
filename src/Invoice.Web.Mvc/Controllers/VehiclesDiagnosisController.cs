using Invoice.Controllers;
using Invoice.VehiclesDiagnosis;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Invoice.Web.Controllers
{
    public class VehiclesDiagnosisController : InvoiceControllerBase
    {
        private readonly IDiagnoseAppService _diagnoseAppService;
        public VehiclesDiagnosisController(IDiagnoseAppService diagnoseAppService)
        {
            _diagnoseAppService = diagnoseAppService;
        }

        public Task<ActionResult> Index(DateTime? fromDate, DateTime? toDate, long? VehicleId, long? municipality, long? region, int? agentId, int page = 1, string keyword = "", string sortBy = "Id", bool sortOrder = false)
        {
            
            
            return View();
        }

    }
}
