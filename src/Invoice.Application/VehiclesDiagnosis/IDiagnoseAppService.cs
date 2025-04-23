using Abp.Application.Services.Dto;
using Invoice.VehiclesDiagnosis.Dto;
using System.Threading.Tasks;

namespace Invoice.VehiclesDiagnosis
{
    public interface IDiagnoseAppService
    {
         Task<PagedResultDto<VehicleDiagnosisDto>> GetAllAsync(PageVehicleDiagnosisResultDto input);
    }
}