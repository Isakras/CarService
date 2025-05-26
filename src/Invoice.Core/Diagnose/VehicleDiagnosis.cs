using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Castle.Core.Resource;
using Invoice.MultiTenancy;
using Invoice.Vehicles;
using Invoice.Workers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Diagnose
{
  public  class VehicleDiagnosis:FullAuditedAggregateRoot<long>, IMustHaveTenant
    {
        public long VehicleId { get; set; }
        
        public long MechanicId { get; set; }
        public string ClientName { get; set; }
        public string PlateNo { get; set; } 

        public DateTime DiagnosisDate { get; set; }

        public string ProblemDescription { get; set; }       // what is the real problem
        public string FixDescription { get; set; }           // how it is fixed
        public decimal Cost { get; set; }                    // how much it cost
        public string Comments { get; set; }
        public int TenantId { get; set; }
        public string PhoneNumber { get; set; } // Client's phone number
        public bool IsPayed { get; set; } // Indicates if the diagnosis has been paid for
        public DateTime? PaymentDate { get; set; } // Date when the diagnosis was paid for, if applicable

        // Navigation properties
        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }

        [ForeignKey("MechanicId")]
        public Mechanic Mechanic { get; set; }
    }
}
