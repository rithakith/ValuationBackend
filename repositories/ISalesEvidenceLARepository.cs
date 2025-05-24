using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface ISalesEvidenceLARepository
    {
        Task<IEnumerable<SalesEvidenceLA>> GetAllAsync();
        Task<SalesEvidenceLA?> GetByIdAsync(int id);
        Task<SalesEvidenceLA?> GetByReportIdAsync(int reportId);
        Task<SalesEvidenceLA> CreateAsync(SalesEvidenceLA salesEvidence, Report report);
        Task UpdateAsync(SalesEvidenceLA salesEvidence);
        Task DeleteAsync(SalesEvidenceLA salesEvidence);
        Task<bool> ExistsAsync(int id);
    }
}
