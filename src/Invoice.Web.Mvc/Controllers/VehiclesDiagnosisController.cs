using Abp;
using Invoice.Controllers;
using Invoice.Diagnose;
using Invoice.Vehicles;
using Invoice.VehiclesDiagnosis;
using Invoice.VehiclesDiagnosis.Dto;
using Invoice.Web.Models.VehicleModules;
using Invoice.Workers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Extensions;

namespace Invoice.Web.Controllers
{
    public class VehiclesDiagnosisController : InvoiceControllerBase
    {
        private readonly IDiagnoseAppService _diagnoseAppService;
        private readonly IVehicleAppService _vehicleAppService;
        private readonly IMechanicAppService _mechanicAppService;
        public VehiclesDiagnosisController(IDiagnoseAppService diagnoseAppService, IVehicleAppService vehicleAppService, IMechanicAppService mechanicAppService)
        {
            _diagnoseAppService = diagnoseAppService;
            _vehicleAppService = vehicleAppService;
            _mechanicAppService = mechanicAppService;
        }

        public async Task<ActionResult> Index(DateTime? fromDate, DateTime? toDate, long? VehicleId, long? municipality, long? region, int? agentId, KeywordType? keywordType, int page = 1, string keyword = "", string sortBy = "Id", bool sortOrder = false)
        {
            long currentUserId = AbpSession.UserId.Value;
            int currentTenantId = AbpSession.TenantId.Value;
            if (fromDate == null)
            {
                DateTime fromDatebegin = DateTime.Now.AddDays(-7); 
                fromDate = (fromDate ?? fromDatebegin).Date;
            }
            toDate = (toDate ?? DateTime.Now).AddDays(1).Date.AddTicks(-1);

            var resultee = await _diagnoseAppService.GetAllExtand(new PageVehicleDiagnosisResultDto()
            {
                Keyword = keyword,
                FromDate = fromDate,
                ToDate = toDate,
                SortBy = sortBy,
                SortOrder = sortOrder,
                SkipCount = (page - 1) * 10, // duhet te vendoset si konstante
                MaxResultCount = 10,  // duhet te vendoset si konstante
                KeywordType = keywordType,
            });

            var multiPageLddist = new VehicleDiagnosePageList<VehicleDiagnosisDto>
            {
                StaticDiagnosePagedList = new StaticPagedList<VehicleDiagnosisDto>(resultee.PagedResult.Items, page, 10, resultee.PagedResult.TotalCount),
                TotalCost = resultee.TotalCost,
                TotalPayed = resultee.TotalPayed,
                TotalUnPayed = resultee.TotalUnPayed
            };

            ViewBag.Keyword = keyword;
            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;
            ViewBag.VehicleId = VehicleId;
            ViewBag.Municipality = municipality;
            ViewBag.Region = region;
            ViewBag.AgentId = agentId;
            ViewBag.KeywordType = keywordType;
            ViewBag.SortBy = sortBy;
            ViewBag.SortOrder = sortOrder;

            return View(multiPageLddist);
        }
        [HttpGet]
        public async Task<ActionResult> CreateAsync()
        {

            var mechanics = await _mechanicAppService.GetAllMechanicList();

            var activeMechaic = mechanics.Where(x => x.IsActive == true);

            ViewBag.Mechanics = activeMechaic
            .Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.FullName
            }).ToList();

            var model = new CreateVehicleDiagnosisDto
            {
                DiagnosisDate = DateTime.Now
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetByVin(string vin)
        {
            var vehicle = await _vehicleAppService.GetByVin(vin);
            if (vehicle == null)
                return Json(new { vehicleId = (long?)null });

            var vehicleId = Json(new { vehicleId = vehicle.Id });
            return Json(new
            {
                vehicleId = vehicle.Id,
                mark = vehicle.Make,
                model = vehicle.Model,
                tablesNo = vehicle.PlateNo
            });
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreateVehicleDiagnosisDto input)
        {

            if (!ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }

            var mechanics = await _diagnoseAppService.CreateAsync(input);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(long id)
        {
            var diagnoses = await _diagnoseAppService.GetVehiclesDiagnosesById(id);

            return View(diagnoses);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePayment(UpdateDiagoseVehicleDto model)
        {

            var diagnoses = await _diagnoseAppService.UpdateDiagiseViehuclePaymet(model);

            TempData["ShowSuccessNotification"] = true;
           // TempData["SuccessMessage"] = "Pagesa u përditësua me sukses!";

            return RedirectToAction("Details", new { id = diagnoses.Id });
        }
    }
}
