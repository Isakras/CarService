using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Expressions;
using Invoice.MechanicHolidays.Dto;
using Invoice.Workers;
using Invoice.Workers.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.MechanicHolidays
{
    /// <summary>
    /// Application service for managing mechanic holidays.
    /// </summary>
    public class MechanicHolidayAppService : AsyncCrudAppService<MechanicHoliday, MechanicHolidayDto, long, PageMechanicHolidayResultDto, CreateMechanicHolidayDto, MechanicHolidayDto>, IMechanicHolidayAppService
    {
        private readonly IRepository<MechanicHoliday, long> _mechanicHolidayRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MechanicHolidayAppService"/> class.
        /// </summary>
        /// <param name="repository">The repository for mechanic holidays.</param>
        public MechanicHolidayAppService(IRepository<MechanicHoliday, long> repository) : base(repository)
        {
            _mechanicHolidayRepository = repository;
        }

        public override async Task<PagedResultDto<MechanicHolidayDto>> GetAllAsync(PageMechanicHolidayResultDto input)
        {
            var mechanicHolidayPredicate = await GetWhereExpressionAsync(input);
            var listMechanicHolidays = new List<MechanicHoliday>();
            var totalDays = 0;
            var query = _mechanicHolidayRepository.GetAllIncluding(x => x.Mechanic)
                .AsNoTracking()
                .Where(mechanicHolidayPredicate)
                .OrderByDescending(x => x.Id);

            listMechanicHolidays = await query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToListAsync();

            totalDays = await query.SumAsync(x => x.NumberOfDays);
            var getMechanicHolidays = new PagedResultDto<MechanicHolidayDto>
            {
                TotalCount = totalDays,
                Items = ObjectMapper.Map<List<MechanicHolidayDto>>(listMechanicHolidays)
            };
            return getMechanicHolidays;
        }

        private async Task<Expression<Func<MechanicHoliday, bool>>> GetWhereExpressionAsync(PageMechanicHolidayResultDto input)
        {
            Expression<Func<MechanicHoliday, bool>> predicate = x => true;
            if (input.MechanicId != null)
            {
                predicate = predicate.And(x => x.MechanicId == input.MechanicId.Value);
                predicate = predicate.And(x => x.StartDate >= input.FromDate && x.StartDate <= input.ToDate);
            }
            else
                predicate = predicate.And(x => x.StartDate >= input.FromDate && x.StartDate <= input.ToDate);
            return predicate;

        }

    

        public override async Task<MechanicHolidayDto> CreateAsync(CreateMechanicHolidayDto input)
        {
            CheckCreatePermission();
            var holiday = ObjectMapper.Map<MechanicHoliday>(input);


            await Repository.InsertAsync(holiday);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(holiday);
        }

    }
}
