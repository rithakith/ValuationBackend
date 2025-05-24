using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface IBuildingRatesLARepository
    {
        Task<IEnumerable<BuildingRatesLA>> GetAllAsync();
        Task<BuildingRatesLA> GetByIdAsync(int id);
        Task<BuildingRatesLA> GetByReportIdAsync(int reportId);
        Task<Report> CreateReportAsync(Report report);
        Task<BuildingRatesLA> CreateAsync(BuildingRatesLA buildingRate);
        Task<bool> UpdateAsync(BuildingRatesLA buildingRate);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
