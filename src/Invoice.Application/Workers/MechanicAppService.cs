using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Invoice.Vehicles;
using Invoice.Workers.Dto;
using Microsoft.AspNetCore.Mvc;
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

        public override async Task<PagedResultDto<MechanicDto>> GetAllAsync(PageMechanicResultDto input)
        {
            var getMechanic = await base.GetAllAsync(input);

            return getMechanic;
        }

        // Implement any additional methods or overrides here if needed.
        public async Task<List<MechanicDto>> GetAllMechanicList()
        {
            var mechanics = await _mechanicRepository.GetAllListAsync();
            return ObjectMapper.Map<List<MechanicDto>>(mechanics);
        }



        [HttpPut]
        public override  async Task<MechanicDto> CreateAsync(CreateMechanicDto input)
        {
            CheckCreatePermission();
            var mechanic = ObjectMapper.Map<Mechanic>(input);


            await Repository.InsertAsync(mechanic);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(mechanic);
        }

    }

   
}
