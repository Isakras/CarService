using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Organizations;
using Invoice.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Workers
{
  public  class Mechanic: FullAuditedAggregateRoot<long>, IMustHaveTenant
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Specialization { get; set; }
        public DateTime HireDate { get; set; }
        public int TenantId { get; set; }
    }
}
