using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Invoice.Diagnose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Invoice.Vehicles;
using Invoice.Workers;
using Invoice.Workers.Dto;
using Invoice.Vehicles.Dto;

namespace Invoice.VehiclesDiagnosis.Dto
{
    [AutoMapFrom(typeof(VehicleDiagnosis))]
    public class VehicleDiagnosisDto : EntityDto<long>
    {
        public long VehicleId { get; set; }
        public long MechanicId { get; set; }
        public string ClientName { get; set; }
        public string PlateNo { get; set; }

        public DateTime DiagnosisDate { get; set; }

        public string ProblemDescription { get; set; }     
        public string FixDescription { get; set; }         
        public decimal Cost { get; set; }                   
        public string Comments { get; set; }
        public MechanicDto Mechanic { get; set; }
        public VehicleDto Vehicle { get; set; }



    }
}