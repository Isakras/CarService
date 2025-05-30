using Invoice.Workers.Dto;
using System.Collections.Generic;

namespace Invoice.Web.Models.MechanicHolidays
{
    public class CreateMechanicHolidayViewModel
    {
        public List<MechanicDto> Workers { get; set; } // DTO with Id and Name
        public int? WorkerId { get; set; }
    }
}
