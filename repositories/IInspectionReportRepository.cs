// filepath: d:\Projects\vd\vd backend\ValuationBackend\repositories\IInspectionReportRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface IInspectionReportRepository
    {
        Task<List<InspectionReport>> GetAllAsync();
        Task<InspectionReport?> GetByIdAsync(int id);
        Task<InspectionReport?> GetByReportIdAsync(int reportId);
        Task<InspectionReport> CreateAsync(InspectionReport inspectionReport, Report report);
        Task UpdateAsync(InspectionReport inspectionReport);
        Task DeleteAsync(InspectionReport inspectionReport);
        Task<Report?> GetReportByIdAsync(int reportId);
        Task DeleteReportAsync(Report report);
        Task AddBuildingAsync(InspectionBuilding building);
        void RemoveBuilding(InspectionBuilding building);
        void RemoveBuildingRange(IEnumerable<InspectionBuilding> buildings);
        Task SaveChangesAsync();
        bool InspectionReportExists(int id);
    }
}
