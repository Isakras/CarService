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
        Task<MechanicDto> CreateAsync(CreateMechanicDto input);
    }
}
