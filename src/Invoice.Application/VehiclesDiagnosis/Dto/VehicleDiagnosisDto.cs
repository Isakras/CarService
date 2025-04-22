using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Invoice.Vehicles;
using Invoice.Workers;
using System;
using Invoice.Diagnose;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice.VehiclesDiagnosis.Dto
{
    [AutoMapFrom(typeof(VehicleDiagnosis))]
    public class VehicleDiagnosisDto : EntityDto<long>
    {
   
        public string ClientName { get; set; } // name of the client who brought the vehicle for diagnosis
        public DateTime DiagnosisDate { get; set; }
        public string ProblemDescription { get; set; }       // what is the real problem
        public string FixDescription { get; set; }           // how it is fixed
        public decimal Cost { get; set; }                    // how much it cost
        public string Comments { get; set; }
        public Vehicle Vehicle { get; set; }
        public Mechanic Mechanic { get; set; }
    }
}