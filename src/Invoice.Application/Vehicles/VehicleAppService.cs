using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Microsoft.EntityFrameworkCore;
using Invoice.Authorization.Users;
using Invoice.Users.Dto;
using Invoice.Vehicles.Dto;
using Microsoft.CodeAnalysis.FlowAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Vehicles
{

    public  class VehicleAppService : AsyncCrudAppService<Vehicle, VehicleDto, long, PageVehiclesResultDto, CreateVehicleDto, VehicleDto>, IVehicleAppService
    {

        private readonly IRepository<Vehicle, long> _vehicleRepository;

        public VehicleAppService (IRepository<Vehicle, long> vehicleRepository) :base(vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public override async Task<PagedResultDto<VehicleDto>> GetAllAsync( PageVehiclesResultDto input)
        {

            var getVehicles = await base.GetAllAsync(input);

            return getVehicles;
        
        }

        [HttpPut]
        public override async  Task<VehicleDto> CreateAsync(CreateVehicleDto input)
        {
            CheckCreatePermission();

            // Map DTO to Entity
            var vehicle = ObjectMapper.Map<Vehicle>(input);


            // Save to the database
            await Repository.InsertAsync(vehicle); // Use InsertAsync not CreateAsync

            await CurrentUnitOfWork.SaveChangesAsync(); // Always await this for changes to persist

            // Return mapped DTO
            return MapToEntityDto(vehicle);
        }
    }
}
