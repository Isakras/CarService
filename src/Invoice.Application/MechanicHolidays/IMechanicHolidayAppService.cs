using Abp.Application.Services.Dto;
using Invoice.MechanicHolidays.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.MechanicHolidays
{
    public interface IMechanicHolidayAppService
    {
        Task<PagedResultDto<MechanicHolidayDto>> GetAllAsync(PageMechanicHolidayResultDto input);
        Task<MechanicHolidayDto> CreateAsync(CreateMechanicHolidayDto input);
        Task DeleteHolidays(long Id);

    }
}
