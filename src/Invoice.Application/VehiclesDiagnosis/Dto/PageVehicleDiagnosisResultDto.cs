using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using Invoice.Diagnose;
using System;

namespace Invoice.VehiclesDiagnosis.Dto
{
    public class PageVehicleDiagnosisResultDto: PagedResultRequestDto, ICustomValidate
    {
        public string Keyword { get; set; }
        public string SortBy { get; set; }
        public bool SortOrder { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

      //  public int? TenantId { get; set; }
      //  public long? UserId { get; set; }

        public KeywordType? KeywordType { get; set; }


        public void AddValidationErrors(CustomValidationContext context)
        {
            if (FromDate == null)
                FromDate = DateTime.Now.Date;
            if (ToDate == null)
                ToDate = DateTime.Now.Date.AddDays(1).AddTicks(-1);
        }
    }
}