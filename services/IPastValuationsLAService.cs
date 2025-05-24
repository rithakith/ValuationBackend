using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;

namespace ValuationBackend.Services
{
    public interface IPastValuationsLAService
    {
        Task<IEnumerable<PastValuationsLAReadDto>> GetAllPastValuationsAsync();
        Task<PastValuationsLAReadDto> GetPastValuationByIdAsync(int id);
        Task<PastValuationsLAReadDto> GetPastValuationByReportIdAsync(int reportId);
        Task<PastValuationsLAReadDto> CreatePastValuationAsync(PastValuationsLACreateDto pastValuationDto);
        Task<PastValuationsLAReadDto> UpdatePastValuationAsync(int id, PastValuationsLAUpdateDto pastValuationDto);
        Task<bool> DeletePastValuationAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
