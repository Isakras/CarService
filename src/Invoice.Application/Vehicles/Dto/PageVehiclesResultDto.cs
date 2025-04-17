﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;

namespace Invoice.Vehicles.Dto
{
    public class PageVehiclesResultDto : PagedResultRequestDto, IShouldNormalize

    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "VIN";
            }

            Keyword = Keyword?.Trim();
        }
    }
}
