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

namespace Invoice.Web.Controllers
{
    public class VehiclesController : InvoiceControllerBase
    {

        private readonly IVehicleAppService _vehicleAppService;

        public VehiclesController(IVehicleAppService vehicleAppService)
        {
            _vehicleAppService = vehicleAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(VehicleImputModel model)
        //{
        //    //if (!ModelState.IsValid)
        //    //    return View(model);

        //    var inderVehicle = ObjectMapper.Map<CreateVehicleDto>(model);


        //    //var dto = new VehicleDto
        //    //{
        //    //    VIN = model.VIN,
        //    //    Make = model.Make,
        //    //    Model = model.Model,
        //    //    Year = model.Year
        //    //};

        //    await _vehicleAppService.CreateAsync(inderVehicle);

        //    TempData["Success"] = "Vehicle added successfully!";
        //    return RedirectToAction("Create"); // or RedirectToAction("Index") if you add a list page
        //}
    }
}
