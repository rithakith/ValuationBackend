using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class BuildingRatesLARepository : IBuildingRatesLARepository
    {
        private readonly AppDbContext _context;

        public BuildingRatesLARepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BuildingRatesLA>> GetAllAsync()
        {
            return await _context.BuildingRatesLA.ToListAsync();
        }

        public async Task<BuildingRatesLA> GetByIdAsync(int id)
        {
            return await _context.BuildingRatesLA.FindAsync(id);
        }

        public async Task<BuildingRatesLA> GetByReportIdAsync(int reportId)
        {
            return await _context.BuildingRatesLA
                .FirstOrDefaultAsync(br => br.ReportId == reportId);
        }

        public async Task<Report> CreateReportAsync(Report report)
        {
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task<BuildingRatesLA> CreateAsync(BuildingRatesLA buildingRate)
        {
            _context.BuildingRatesLA.Add(buildingRate);
            await _context.SaveChangesAsync();
            return buildingRate;
        }

        public async Task<bool> UpdateAsync(BuildingRatesLA buildingRate)
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ExistsAsync(buildingRate.Id))
                {
                    return false;
                }
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var buildingRate = await GetByIdAsync(id);
            if (buildingRate == null)
            {
                return false;
            }

            // Delete associated report
            var report = await _context.Reports.FindAsync(buildingRate.ReportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            _context.BuildingRatesLA.Remove(buildingRate);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.BuildingRatesLA.AnyAsync(e => e.Id == id);
        }
    }
}
