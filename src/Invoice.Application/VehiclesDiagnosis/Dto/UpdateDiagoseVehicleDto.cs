using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.VehiclesDiagnosis.Dto
{
   public class UpdateDiagoseVehicleDto
    {
        public long Id { get; set; }
        public bool MarkAsPayed { get; set; }
        public DateTime? SelectedPaymentDate { get; set; }
    }
}
