using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface IConditionReportRepository
    {
        Task<IEnumerable<ConditionReport>> GetAllAsync();
        Task<ConditionReport> GetByIdAsync(int id);
        Task<ConditionReport> GetByReportIdAsync(int reportId);
        Task<Report> CreateReportAsync(Report report);
        Task<ConditionReport> CreateAsync(ConditionReport conditionReport);
        Task<bool> UpdateAsync(ConditionReport conditionReport);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
