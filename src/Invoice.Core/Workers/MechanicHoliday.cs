using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Workers
{
    public class MechanicHoliday : FullAuditedAggregateRoot<long>, IMustHaveTenant
    {
        public long MechanicId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfDays { get; set; }
        public Mechanic Mechanic { get; set; }
        public int TenantId { get; set; }
        public string Comment { get; set; }
    }
}
