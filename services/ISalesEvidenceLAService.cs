using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;

namespace ValuationBackend.Services
{
    public interface ISalesEvidenceLAService
    {
        Task<IEnumerable<SalesEvidenceLAResponseDto>> GetAllSalesEvidencesAsync();
        Task<SalesEvidenceLAResponseDto> GetSalesEvidenceByIdAsync(int id);
        Task<SalesEvidenceLAResponseDto> GetSalesEvidenceByReportIdAsync(int reportId);
        Task<SalesEvidenceLAResponseDto> CreateSalesEvidenceAsync(SalesEvidenceLACreateDto salesEvidenceDto);
        Task<SalesEvidenceLAResponseDto> UpdateSalesEvidenceAsync(int id, SalesEvidenceLAUpdateDto salesEvidenceDto);
        Task<bool> DeleteSalesEvidenceAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
