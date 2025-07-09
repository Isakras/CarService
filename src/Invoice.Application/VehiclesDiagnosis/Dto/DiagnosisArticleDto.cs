using Abp.AutoMapper;
using Invoice.Diagnose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.VehiclesDiagnosis.Dto
{
    [AutoMapFrom(typeof(DiagnosisArticle))]
    [AutoMapTo(typeof(DiagnosisArticle))]
    public  class DiagnosisArticleDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal Total => Quantity * Price;
    }
}
