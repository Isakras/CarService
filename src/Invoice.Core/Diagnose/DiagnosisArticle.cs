using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Diagnose
{
   public class DiagnosisArticle : FullAuditedAggregateRoot<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public long VehicleDiagnosisId { get; set; }

        [ForeignKey(nameof(VehicleDiagnosisId))]
        public VehicleDiagnosis VehicleDiagnosis { get; set; }

        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total => Quantity * Price;

    }
}
