using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Invoice.Vehicles;
using System.Runtime.Serialization;
using AutoMapper.Internal.Mappers;
using NuGet.Protocol.Plugins;
using Invoice.Vehicles.Dto;
using Abp.ObjectMapping;
using System.Collections.Generic;
using Invoice.Controllers;
using Invoice.Web.Models.VehicleModules;
using Microsoft.AspNetCore.Components.Forms;

namespace Invoice.Web.Controllers
{
    public class VehiclesController : InvoiceControllerBase
    {

        private readonly IVehicleAppService _vehicleAppService;

        public VehiclesController(IVehicleAppService vehicleAppService)
        {
            _vehicleAppService = vehicleAppService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
