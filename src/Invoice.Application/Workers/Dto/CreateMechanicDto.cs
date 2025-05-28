using Abp.AutoMapper;
using System;

namespace Invoice.Workers.Dto
{
    [AutoMapTo(typeof(Mechanic))]
    public class CreateMechanicDto
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Specialization { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
    }
}