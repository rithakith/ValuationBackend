using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface ILMSalesEvidenceRepository
    {
        Task<IEnumerable<LMSalesEvidence>> GetAllAsync();
        Task<LMSalesEvidence> GetByIdAsync(int id);
        Task<LMSalesEvidence> GetByIdWithMasterFileAsync(int id);
        Task<IEnumerable<LMSalesEvidence>> GetByMasterFileIdAsync(int masterFileId);
        Task<LMSalesEvidence> GetByReportIdAsync(int reportId);
        Task<Report> CreateReportAsync(Report report);
        Task<LMSalesEvidence> CreateAsync(LMSalesEvidence lmSalesEvidence);
        Task<bool> UpdateAsync(LMSalesEvidence lmSalesEvidence);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int reportId);
    }
}
