using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;

namespace Invoice.Workers.Dto
{
    [AutoMapFrom(typeof(Mechanic))]
    public class MechanicDto : EntityDto<long>
    {
        public string FullName { get; set; }
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Specialization { get; set; }
        public DateTime HireDate { get; set; }
    }
}