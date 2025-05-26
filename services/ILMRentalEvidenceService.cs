using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;

namespace ValuationBackend.Services
{
    public interface ILMRentalEvidenceService
    {
        Task<IEnumerable<LMRentalEvidenceResponseDto>> GetAllAsync();
        Task<LMRentalEvidenceResponseDto> GetByIdAsync(int id);
        Task<LMRentalEvidenceResponseDto> GetByReportIdAsync(int reportId);
        Task<LMRentalEvidenceResponseDto> CreateAsync(LMRentalEvidenceCreateDto dto);
        Task<bool> UpdateAsync(int reportId, LMRentalEvidenceUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
