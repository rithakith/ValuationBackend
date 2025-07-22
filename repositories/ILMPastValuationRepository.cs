using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface ILMPastValuationRepository
    {
        Task<IEnumerable<LMPastValuation>> GetAllAsync();
        Task<LMPastValuation> GetByIdAsync(int id);
        Task<LMPastValuation> GetByIdWithMasterFileAsync(int id);
        Task<IEnumerable<LMPastValuation>> GetByMasterFileIdAsync(int masterFileId);
        Task<LMPastValuation> GetByReportIdAsync(int reportId);
        Task<Report> CreateReportAsync(Report report);
        Task<LMPastValuation> CreateAsync(LMPastValuation lmPastValuation);
        Task<bool> UpdateAsync(LMPastValuation lmPastValuation);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int reportId);
    }
}
