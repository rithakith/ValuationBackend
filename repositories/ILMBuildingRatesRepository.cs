using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface ILMBuildingRatesRepository
    {
        Task<IEnumerable<LMBuildingRates>> GetAllAsync();
        Task<LMBuildingRates> GetByIdAsync(int id);
        Task<LMBuildingRates> GetByReportIdAsync(int reportId);
        Task<Report> CreateReportAsync(Report report);
        Task<LMBuildingRates> CreateAsync(LMBuildingRates lmBuildingRate);
        Task<bool> UpdateAsync(LMBuildingRates lmBuildingRate);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int reportId);
    }
}
