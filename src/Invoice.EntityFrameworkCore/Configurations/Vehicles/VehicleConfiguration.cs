using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Invoice.Vehicles;
using System.Threading.Tasks;

namespace Invoice.Configurations.Vehicles
{
    class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Vehicle> builder)
        {
            throw new NotImplementedException();
        }
    }
}
