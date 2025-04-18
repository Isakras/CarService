using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using Invoice.Diagnose;
using System;
using System.Reflection;

namespace Invoice.VehiclesDiagnosis.Dto

{
    public class PageVehicleDiagnosisResultDto : PagedResultRequestDto, ICustomValidate
    {
        public string Keyword { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public KeywordType KeywordType { get; set; }
        public void AddValidationErrors(CustomValidationContext context)
        {
            if (FromDate == null)
                FromDate = DateTime.Now.Date;
            if (ToDate == null)
                ToDate = DateTime.Now.Date.AddDays(1).AddTicks(-1);
        }
    }
}