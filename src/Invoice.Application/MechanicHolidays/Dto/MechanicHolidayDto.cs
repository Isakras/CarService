using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Invoice.Workers;
using System;

namespace Invoice.MechanicHolidays.Dto
{
    [AutoMapFrom(typeof(MechanicHoliday))]
    public class MechanicHolidayDto : EntityDto<long>
    {
        public long MechanicId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfDays { get; set; }
        public string Comment { get; set; }
        public Mechanic Mechanic { get; set; }
   
    }
}