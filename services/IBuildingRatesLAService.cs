using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;

namespace ValuationBackend.Services
{
    public interface IBuildingRatesLAService
    {
        Task<IEnumerable<BuildingRatesLAResponseDto>> GetAllAsync();
        Task<BuildingRatesLAResponseDto> GetByIdAsync(int id);
        Task<BuildingRatesLAResponseDto> GetByReportIdAsync(int reportId);
        Task<BuildingRatesLAResponseDto> CreateAsync(BuildingRatesLACreateDto dto);
        Task<bool> UpdateAsync(int id, BuildingRatesLAUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
