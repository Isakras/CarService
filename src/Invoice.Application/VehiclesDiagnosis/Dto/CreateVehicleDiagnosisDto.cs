using Abp.AutoMapper;
using Invoice.Diagnose;
using Invoice.Vehicles;
using Invoice.Workers;
using System;

namespace Invoice.VehiclesDiagnosis.Dto
{
    [AutoMapTo(typeof(VehicleDiagnosis))]
    public class CreateVehicleDiagnosisDto
    {
        public string ClientName { get; set; } // name of the client who brought the vehicle for diagnosis
        public DateTime DiagnosisDate { get; set; }
        public string ProblemDescription { get; set; }       // what is the real problem
        public string FixDescription { get; set; }           // how it is fixed
        public decimal Cost { get; set; }                    // how much it cost
        public string Comments { get; set; }
        public long VehicleId { get; set; }
        public long MechanicId { get; set; }
        public string PlateNo { get; set; }
    }
}