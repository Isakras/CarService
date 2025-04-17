using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using Invoice.Vehicles;
using Invoice.Vehicles.Dto;

namespace Invoice.Web.Models.VehicleModules
{
    [AutoMapTo(typeof(CreateVehicleDto))]
    public class VehicleImputModel
    {




        public string VIN { get; set; }



        public string Make { get; set; }



        public string Model { get; set; }


        public int Year { get; set; }
        public string Color { get; set; }
    }
}
