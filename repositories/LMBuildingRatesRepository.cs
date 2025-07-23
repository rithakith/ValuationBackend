using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class LMBuildingRatesRepository : ILMBuildingRatesRepository
    {
        private readonly AppDbContext _context;

        public LMBuildingRatesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LMBuildingRates>> GetAllAsync()
        {
            return await _context.LMBuildingRates.ToListAsync();
        }

        public async Task<LMBuildingRates> GetByIdAsync(int id)
        {
            return await _context.LMBuildingRates.FindAsync(id);
        }

        public async Task<LMBuildingRates> GetByIdWithMasterFileAsync(int id)
        {
            return await _context.LMBuildingRates
                .Include(br => br.LandMiscellaneousMasterFile)
                .FirstOrDefaultAsync(br => br.Id == id);
        }

        public async Task<IEnumerable<LMBuildingRates>> GetByMasterFileIdAsync(int masterFileId)
        {
            return await _context.LMBuildingRates
                .Where(br => br.LandMiscellaneousMasterFileId == masterFileId)
                .Include(br => br.LandMiscellaneousMasterFile)
                .ToListAsync();
        }

        public async Task<LMBuildingRates> GetByReportIdAsync(int reportId)
        {
            return await _context.LMBuildingRates
                .FirstOrDefaultAsync(lr => lr.ReportId == reportId);
        }
        public async Task<Report> CreateReportAsync(Report report)
        {
            report.Timestamp = DateTime.UtcNow;
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task<LMBuildingRates> CreateAsync(LMBuildingRates lmBuildingRate)
        {
            _context.LMBuildingRates.Add(lmBuildingRate);
            await _context.SaveChangesAsync();
            return lmBuildingRate;
        }

        public async Task<bool> UpdateAsync(LMBuildingRates lmBuildingRate)
        {
            try
            {
                _context.Entry(lmBuildingRate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var lmBuildingRate = await _context.LMBuildingRates.FindAsync(id);
            if (lmBuildingRate == null)
            {
                return false;
            }

            var report = await _context.Reports.FindAsync(lmBuildingRate.ReportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            _context.LMBuildingRates.Remove(lmBuildingRate);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int reportId)
        {
            return await _context.LMBuildingRates.AnyAsync(e => e.ReportId == reportId);
        }
    }
}
