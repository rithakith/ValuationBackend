using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;

namespace ValuationBackend.Services
{
    public interface ILMSalesEvidenceService
    {
        Task<IEnumerable<LMSalesEvidenceResponseDto>> GetAllAsync();
        Task<LMSalesEvidenceResponseDto> GetByIdAsync(int id);
        Task<LMSalesEvidenceResponseDto> GetByReportIdAsync(int reportId);
        Task<LMSalesEvidenceResponseDto> CreateAsync(LMSalesEvidenceCreateDto dto);
        Task<bool> UpdateAsync(int reportId, LMSalesEvidenceUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
