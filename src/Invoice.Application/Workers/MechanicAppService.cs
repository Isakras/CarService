using Abp.Application.Services;
using Abp.Domain.Repositories;
using Invoice.Workers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Invoice.Workers
{
  public  class MechanicAppService : AsyncCrudAppService<Mechanic, MechanicDto, long, PageMechanicResultDto, CreateMechanicDto, MechanicDto>, IMechanicAppService
    {
        private readonly IRepository<Mechanic, long> _mechanicRepository;
        public MechanicAppService(IRepository<Mechanic, long> mechanicRepository) : base(mechanicRepository)
        {
            _mechanicRepository = mechanicRepository;
        }

        // Implement any additional methods or overrides here if needed.
        public async Task<List<MechanicDto>> GetAllMechanicList()
        {
            var mechanics = await _mechanicRepository.GetAllListAsync();
            return ObjectMapper.Map<List<MechanicDto>>(mechanics);
        }
  
    }

   
}
