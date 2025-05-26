using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;

namespace ValuationBackend.Services
{
    public interface ILMBuildingRatesService
    {
        Task<IEnumerable<LMBuildingRatesResponseDto>> GetAllAsync();
        Task<LMBuildingRatesResponseDto> GetByIdAsync(int id);
        Task<LMBuildingRatesResponseDto> GetByReportIdAsync(int reportId);
        Task<LMBuildingRatesResponseDto> CreateAsync(LMBuildingRatesCreateDto dto);
        Task<bool> UpdateAsync(int reportId, LMBuildingRatesUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
