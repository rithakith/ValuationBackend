using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface IRentalEvidenceLARepository
    {
        Task<IEnumerable<RentalEvidenceLA>> GetAllAsync();
        Task<RentalEvidenceLA?> GetByIdAsync(int id);
        Task<RentalEvidenceLA?> GetByReportIdAsync(int reportId);
        Task<RentalEvidenceLA> CreateAsync(RentalEvidenceLA rentalEvidence, Report report);
        Task UpdateAsync(RentalEvidenceLA rentalEvidence);
        Task DeleteAsync(RentalEvidenceLA rentalEvidence);
        Task<bool> ExistsAsync(int id);
    }
}
