using Abp.Application.Services;
using Abp.Domain.Repositories;
using Invoice.Diagnose;
using Invoice.VehiclesDiagnosis.Dto;
using Invoice.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Abp.Application.Services.Dto;
using Invoice.Vehicles.Dto;
using System.Linq.Expressions;
using Abp.Specifications;
using Microsoft.EntityFrameworkCore;
using Abp.Linq.Extensions;

namespace Invoice.VehiclesDiagnosis
{
    /// <summary>
    /// Provides services related to vehicle diagnoses.
    /// </summary>
    public class DiagnoseAppService : AsyncCrudAppService<VehicleDiagnosis, VehicleDiagnosisDto, long, PageVehicleDiagnosisResultDto, CreateVehicleDiagnosisDto, VehicleDiagnosisDto>, IDiagnoseAppService
    {

        // Implement any additional methods or overrides here if needed.

        private readonly IRepository<VehicleDiagnosis, long> _vehicleRepository;
        public DiagnoseAppService(IRepository<VehicleDiagnosis, long> repository) : base(repository)
        {
            _vehicleRepository = repository;
        }
       
        public override async Task<PagedResultDto<VehicleDiagnosisDto>> GetAllAsync(PageVehicleDiagnosisResultDto input)
        {
            var diagnosePredicate = await GetWhereExpressionAsync(input);

            var listDiagnose = new List<VehicleDiagnosis>();
            var listDiagnose1 = new List<VehicleDiagnosis>();
            var TotalCount = 0;

            var query = _vehicleRepository.GetAllIncluding(x => x.Vehicle, x => x.Mechanic)
                .AsNoTracking()
                .Where(diagnosePredicate)
                .OrderByDescending(x => x.Id);

            listDiagnose = await query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToListAsync();


            listDiagnose1 = query.PageBy(input.SkipCount,input.MaxResultCount).ToList();

            TotalCount = await query.CountAsync();
            var getDiagnose = new PagedResultDto<VehicleDiagnosisDto>
            {
                TotalCount = TotalCount,
                Items = ObjectMapper.Map<List<VehicleDiagnosisDto>>(listDiagnose)
            };
            return getDiagnose;

        }

        private async Task<Expression<Func<VehicleDiagnosis, bool>>> GetWhereExpressionAsync(PageVehicleDiagnosisResultDto input)
        {
           Expression<Func<VehicleDiagnosis, bool>> predicate = x => true;
          

            if (!string.IsNullOrEmpty(input.Keyword))
            {
                if (input.KeywordType == KeywordType.Vin)
                {
                    predicate = predicate.And(x => x.Vehicle.VIN == input.Keyword);
                }
                if (input.KeywordType == KeywordType.TableNo)
                {
                    predicate = predicate.And(x => x.Vehicle.PlateNo == input.Keyword);
                }
                if (input.KeywordType == KeywordType.Worker)
                {
                    predicate = predicate.And(x => x.Mechanic.FullName.Contains(input.Keyword));
                }
               if (input.KeywordType == KeywordType.ClientName)
                {
                    predicate = predicate.And(x => x.ClientName.Contains(input.Keyword));
                }
            }
            else
                predicate = predicate.And(x => x.DiagnosisDate >= input.FromDate && x.DiagnosisDate <= input.ToDate);
            
            return predicate;
        }
    }

}
