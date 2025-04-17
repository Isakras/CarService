using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Vehicles.Dto
{
    [AutoMapFrom(typeof(Vehicle))]
   public class VehicleDto : EntityDto<long>
    {
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string PlateNo { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }

    }
}
