using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface IPastValuationsLARepository
    {
        Task<IEnumerable<PastValuationsLA>> GetAllAsync();
        Task<PastValuationsLA?> GetByIdAsync(int id);
        Task<PastValuationsLA?> GetByReportIdAsync(int reportId);
        Task<PastValuationsLA> CreateAsync(PastValuationsLA pastValuation, Report report);
        Task UpdateAsync(PastValuationsLA pastValuation);
        Task DeleteAsync(PastValuationsLA pastValuation);
        Task<bool> ExistsAsync(int id);
    }
}
