// filepath: d:\Projects\vd\vd backend\ValuationBackend\repositories\InspectionReportRepository.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class InspectionReportRepository : IInspectionReportRepository
    {
        private readonly AppDbContext _context;

        public InspectionReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<InspectionReport>> GetAllAsync()
        {
            return await _context.InspectionReports
                .Include(ir => ir.Buildings)
                .ToListAsync();
        }

        public async Task<InspectionReport?> GetByIdAsync(int id)
        {
            return await _context.InspectionReports
                .Include(ir => ir.Buildings)
                .FirstOrDefaultAsync(ir => ir.InspectionReportId == id);
        }

        public async Task<InspectionReport?> GetByReportIdAsync(int reportId)
        {
            return await _context.InspectionReports
                .Include(ir => ir.Buildings)
                .FirstOrDefaultAsync(ir => ir.ReportId == reportId);
        }

        public async Task<InspectionReport> CreateAsync(InspectionReport inspectionReport, Report report)
        {
            // Add the report first
            _context.Reports.Add(report);
            await _context.SaveChangesAsync(); // Save to get ReportId

            inspectionReport.ReportId = report.ReportId; // Assign the generated ReportId

            _context.InspectionReports.Add(inspectionReport);
            await _context.SaveChangesAsync();
            return inspectionReport;
        }

        public async Task UpdateAsync(InspectionReport inspectionReport)
        {
            _context.Entry(inspectionReport).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(InspectionReport inspectionReport)
        {
            _context.InspectionReports.Remove(inspectionReport);
            await _context.SaveChangesAsync();
        }

        public async Task<Report?> GetReportByIdAsync(int reportId)
        {
            return await _context.Reports.FindAsync(reportId);
        }

        public async Task DeleteReportAsync(Report report)
        {
            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
        }

        public async Task AddBuildingAsync(InspectionBuilding building)
        {
            await _context.InspectionBuildings.AddAsync(building);
            // SaveChangesAsync will be called by UpdateAsync on the parent report or explicitly by SaveChangesAsync()
        }

        public void RemoveBuilding(InspectionBuilding building)
        {
            _context.InspectionBuildings.Remove(building);
        }

        public void RemoveBuildingRange(IEnumerable<InspectionBuilding> buildings)
        {
            _context.InspectionBuildings.RemoveRange(buildings);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public bool InspectionReportExists(int id)
        {
            return _context.InspectionReports.Any(e => e.InspectionReportId == id);
        }
    }
}
