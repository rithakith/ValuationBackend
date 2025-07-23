using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;

namespace ValuationBackend.Services
{
    public interface ILMPastValuationService
    {
        Task<IEnumerable<LMPastValuationResponseDto>> GetAllAsync();
        Task<LMPastValuationResponseDto> GetByIdAsync(int id);
        Task<IEnumerable<LMPastValuationResponseDto>> GetByMasterFileIdAsync(int masterFileId);
        Task<LMPastValuationResponseDto> GetByReportIdAsync(int reportId);
        Task<LMPastValuationResponseDto> CreateAsync(LMPastValuationCreateDto dto);
        Task<bool> UpdateAsync(int reportId, LMPastValuationUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
