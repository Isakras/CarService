using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Invoice.Vehicles;
using Invoice.Workers;
using System;
using Invoice.Diagnose;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

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
        public string PhoneNumber { get; set; } // Client's phone number
        public bool IsPayed { get; set; } // Indicates if the diagnosis has been paid for
        public DateTime? PaymentDate { get; set; }
        public Vehicle Vehicle { get; set; }
        public Mechanic Mechanic { get; set; }
        public List<DiagnosisArticleDto> Articles { get; set; } = new();
        public string PlateNo { get; set; } 
    }
}