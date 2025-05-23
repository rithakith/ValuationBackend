using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;

namespace ValuationBackend.Services
{
    public interface IRentalEvidenceLAService
    {
        Task<IEnumerable<RentalEvidenceLAResponseDto>> GetAllRentalEvidencesAsync();
        Task<RentalEvidenceLAResponseDto> GetRentalEvidenceByIdAsync(int id);
        Task<RentalEvidenceLAResponseDto> GetRentalEvidenceByReportIdAsync(int reportId);
        Task<RentalEvidenceLAResponseDto> CreateRentalEvidenceAsync(RentalEvidenceLACreateDto rentalEvidenceDto);
        Task<RentalEvidenceLAResponseDto> UpdateRentalEvidenceAsync(int id, RentalEvidenceLAUpdateDto rentalEvidenceDto);
        Task<bool> DeleteRentalEvidenceAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
