using Abp.Application.Services.Dto;
using Invoice.Workers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Workers
{
   public interface IMechanicAppService
    {
        Task<List<MechanicDto>> GetAllMechanicList();
        Task<PagedResultDto<MechanicDto>> GetAllAsync(PageMechanicResultDto input);
        Task<MechanicDto> CreateAsync(CreateMechanicDto input);
        Task<MechanicDto> GetMechanicByIdAsync(long mechanicId);
        Task<MechanicDto> UpdateMechanicAsync(MechanicDto input);
    }
}
