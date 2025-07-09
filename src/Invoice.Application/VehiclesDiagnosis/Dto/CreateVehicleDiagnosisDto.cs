using Abp.AutoMapper;
using Invoice.Diagnose;
using Invoice.Vehicles;
using Invoice.Workers;
using System;
using System.Collections.Generic;

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
        public string PhoneNumber { get; set; } // Client's phone number
        public bool IsPayed { get; set; } // Indicates if the diagnosis has been paid for
        public DateTime? PaymentDate { get; set; }
        public List<ArticlesDto> Articles { get; set; } = new();
    }
}