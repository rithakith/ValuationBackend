using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface ILMRentalEvidenceRepository
    {
        Task<IEnumerable<LMRentalEvidence>> GetAllAsync();
        Task<LMRentalEvidence> GetByIdAsync(int id);
        Task<LMRentalEvidence> GetByReportIdAsync(int reportId);

        // NEW: Methods for foreign key relationship
        Task<IEnumerable<LMRentalEvidence>> GetByMasterFileIdAsync(int masterFileId);
        Task<IEnumerable<LMRentalEvidence>> GetByMasterFileRefNoAsync(string masterFileRefNo);
        Task<IEnumerable<LMRentalEvidence>> GetAllWithMasterFileDataAsync();
        Task<LandMiscellaneousMasterFile?> GetMasterFileByRefNoAsync(string refNo);

        Task<Report> CreateReportAsync(Report report);
        Task<LMRentalEvidence> CreateAsync(LMRentalEvidence lmRentalEvidence);
        Task<bool> UpdateAsync(LMRentalEvidence lmRentalEvidence);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int reportId);
    }
}
