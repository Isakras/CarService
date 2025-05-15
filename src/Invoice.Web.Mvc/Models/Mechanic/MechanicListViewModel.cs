using Invoice.Roles.Dto;
using Invoice.Vehicles.Dto;
using Invoice.Workers.Dto;
using System.Collections.Generic;

namespace Invoice.Web.Models.Mechanic
{
    public class MechanicListViewModel
    {
        public IReadOnlyList<MechanicDto> Mechanics { get; set; }
    }
}
