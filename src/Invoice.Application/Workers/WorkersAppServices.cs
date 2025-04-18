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
    class WorkersAppServices : AsyncCrudAppService<Mechanic, MechanicDto, long, PageMechanicResultDto, CreateMechanicDto, MechanicDto>, IWorkersAppServices
    {
        private readonly IRepository<Mechanic, long> _mechanicRepository;
        public WorkersAppServices(IRepository<Mechanic, long> repository) : base(repository)
        {
            _mechanicRepository = repository;
        }
    }

}
