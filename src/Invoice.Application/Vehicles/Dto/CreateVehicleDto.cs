using Abp.Authorization.Users;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Vehicles.Dto
{
    [AutoMapTo(typeof(Vehicle))]
    public class CreateVehicleDto
    {
        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
    }
}
