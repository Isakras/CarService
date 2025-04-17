using Invoice.Roles.Dto;
using Invoice.Vehicles.Dto;
using System.Collections.Generic;

namespace Invoice.Web.Models.VehicleModules
{
    public class VehicleListViewModel
    {
        public IReadOnlyList<VehicleDto> Vehicle { get; set; }
    }
}
