using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.VehiclesDiagnosis.Dto
{
    class VehiuclesDiagnosesExResultDto <T>
    {
        public PagedResultDto<T> PagedResult { get; set; }
        public decimal TotalCost { get; set; }
    }
}
