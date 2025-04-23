using Abp;
using Invoice.Controllers;
using Invoice.Diagnose;
using Invoice.VehiclesDiagnosis;
using Invoice.VehiclesDiagnosis.Dto;
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

        public async Task<ActionResult> Index(DateTime? fromDate, DateTime? toDate, long? VehicleId, long? municipality, long? region, int? agentId, KeywordType? keywordType, int page = 1,  string keyword = "", string sortBy = "Id", bool sortOrder = false)
        {

            long currentUserId = AbpSession.UserId.Value;
            int currentTenantId = AbpSession.TenantId.Value;
            DateTime fromDatebegin = new DateTime(2025, 1, 1);
            fromDate = (fromDate ?? fromDatebegin).Date;
            toDate = (toDate ?? DateTime.Now).AddDays(1).Date.AddTicks(-1);

            var diagnose = await _diagnoseAppService.GetAllAsync( new PageVehicleDiagnosisResultDto()
            {
                Keyword = keyword,
                FromDate = fromDate,
                ToDate = toDate,
                SortBy = sortBy,
                SortOrder = sortOrder,
                SkipCount = (page -1) * 10,// duhet te vendoset si konstante
                MaxResultCount = 10,  // duhet te vendoset si konstante
                KeywordType = keywordType,
            });
            return View(diagnose);
        }

    }
}
