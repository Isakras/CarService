using Abp.Application.Services.Dto;
using Invoice.VehiclesDiagnosis.Dto;
using System.Threading.Tasks;

namespace Invoice.VehiclesDiagnosis
{
    public interface IDiagnoseAppService
    {
        Task<PagedResultDto<VehicleDiagnosisDto>> GetAllAsync(PageVehicleDiagnosisResultDto input);
        Task<VehicleDiagnosisDto> CreateAsync(CreateVehicleDiagnosisDto input);
        Task<VehicleDiagnosisDto> GetVehiclesDiagnosesById(long id);
        Task<VehiuclesDiagnosesExResultDto<VehicleDiagnosisDto>> GetAllExtand(PageVehicleDiagnosisResultDto input);
        Task<VehicleDiagnosisDto> UpdateDiagiseViehuclePaymet(UpdateDiagoseVehicleDto model);
        Task DeleteHolidays(long Id);
    }
}