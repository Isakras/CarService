using Abp.AutoMapper;
using Invoice.Diagnose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.VehiclesDiagnosis.Dto
{
    [AutoMapTo(typeof(DiagnosisArticle))]
    public class ArticlesDto
    {
     
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
     
    }
}
