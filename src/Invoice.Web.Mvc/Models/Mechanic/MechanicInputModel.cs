using System;
using Abp.AutoMapper;
using Invoice.Workers.Dto;

namespace Invoice.Web.Models.Mechanic
{
    [AutoMapTo(typeof(CreateMechanicDto))]
    public class MechanicInputModel
    {

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Specialization { get; set; }
        public DateTime HireDate { get; set; }
        // Add any additional properties or validation attributes as needed
    }
}
