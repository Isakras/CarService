using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.VehiclesDiagnosis.Dto
{
   public class VehiuclesDiagnosesExResultDto <T>
    {
        public PagedResultDto<T> PagedResult { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalPayed { get; set; }
        public decimal TotalUnPayed { get; set; }
    }
}
