using Abp.Domain.Entities.Auditing;
using Castle.Core.Resource;
using Invoice.Vehicles;
using Invoice.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Diagnose
{
  public  class VehicleDiagnosis:FullAuditedAggregateRoot<long>
    {
        public long VehicleId { get; set; }
        public long MechanicId { get; set; }

        public DateTime DiagnosisDate { get; set; }

        public string ProblemDescription { get; set; }       // what is the real problem
        public string FixDescription { get; set; }           // how it is fixed
        public decimal Cost { get; set; }                    // how much it cost
        public string Comments { get; set; }

        // Navigation properties

        public Vehicle Vehicle { get; set; }
        public Mechanic Mechanic { get; set; }
    }
}
