using X.PagedList;

namespace Invoice.Web.Models.VehicleModules
{
    public class VehicleDiagnosePageList <T>
    {
        public StaticPagedList<T> StaticDiagnosePagedList { get; set; }
        public decimal TotalCost { get; set; }


    }
}
