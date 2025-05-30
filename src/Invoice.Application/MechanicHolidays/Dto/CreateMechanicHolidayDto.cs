using Abp.AutoMapper;
using Invoice.Workers;
using System;

namespace Invoice.MechanicHolidays.Dto
{
    [AutoMapTo(typeof(MechanicHoliday))]
    public class CreateMechanicHolidayDto
    {
        public long MechanicId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfDays { get; set; }
        public string Comment { get; set; }
    }
}