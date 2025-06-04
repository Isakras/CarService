using Invoice.Controllers;
using Invoice.MechanicHolidays;
using Invoice.MechanicHolidays.Dto;
using Invoice.Workers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;
using X.PagedList;
using Invoice.Web.Models.MechanicHolidays;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Invoice.Web.Controllers
{
    public class MechanicHolidaysController : InvoiceControllerBase
    {
        readonly IMechanicHolidayAppService _mechanicHolidayAppService;
        readonly IMechanicAppService _mechanic;
        public MechanicHolidaysController(IMechanicHolidayAppService mechanicHolidayAppService, IMechanicAppService mechanic)
        {
            _mechanicHolidayAppService = mechanicHolidayAppService;
            _mechanic = mechanic;
        }

        public async Task<ActionResult> Index(DateTime? fromDate, DateTime? toDate, long? workerId, int page = 1)
        {

            long currentUserId = AbpSession.UserId.Value;
            int currentTenantId = AbpSession.TenantId.Value;
            if (fromDate == null)
            {
                DateTime fromDatebegin = DateTime.Now.AddDays(-7);
                fromDate = (fromDate ?? fromDatebegin).Date;
            }
            toDate = (toDate ?? DateTime.Now).AddDays(1).Date.AddTicks(-1);

            var result = await _mechanicHolidayAppService.GetAllAsync(new PageMechanicHolidayResultDto()
            {
                FromDate = fromDate,
                ToDate = toDate,
                MechanicId = workerId,
                SkipCount = (page - 1) * 10, // duhet te vendoset si konstante
                MaxResultCount = 10,// Default value for pagination
            });

            var listResult = new StaticPagedList<MechanicHolidayDto>(result.Items, page, 10, result.TotalCount);


            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;
            ViewBag.WorkerId = workerId;

                      var mechanics = await _mechanic.GetAllMechanicList();

            var activeMechaic = mechanics.Where(x => x.IsActive == true);

            ViewBag.Mechanics = activeMechaic
            .Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.FullName
            }).ToList();

            return View(listResult);
        }

        [HttpGet]
        public async Task<ActionResult> CreateModal()
        {
            var workers = await _mechanic.GetAllMechanicList();  // returns List<WorkerDto>

            var activeMechaic = workers.Where(x => x.IsActive == true);

            var model = new CreateMechanicHolidayViewModel
            {
                Workers = activeMechaic.ToList() // or just 'workers' if already a list
            };

            return PartialView("_CreateHolidayModal", model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMechanicHolidayDto model)
        {
            if (ModelState.IsValid)
            {
                // Map and save to DB
                await _mechanicHolidayAppService.CreateAsync(model); // Example service
                return Json(new { success = true });
            }

            return BadRequest("Invalid data");
        }


        public async Task<IActionResult> Delete(long id)
        {
            await _mechanicHolidayAppService.DeleteHolidays(id); // Corrected: Removed assignment to a variable since DeleteHolidays returns void.

            return Json(new { success = true, message = "Pushimi u fshi me sukses!" });
        }
    }
}
