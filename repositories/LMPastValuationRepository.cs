using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class LMPastValuationRepository : ILMPastValuationRepository
    {
        private readonly AppDbContext _context;

        public LMPastValuationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LMPastValuation>> GetAllAsync()
        {
            return await _context.LMPastValuations.ToListAsync();
        }

        public async Task<LMPastValuation> GetByIdAsync(int id)
        {
            return await _context.LMPastValuations.FindAsync(id);
        }

        public async Task<LMPastValuation> GetByReportIdAsync(int reportId)
        {
            return await _context.LMPastValuations
                .FirstOrDefaultAsync(pv => pv.ReportId == reportId);
        }

        public async Task<Report> CreateReportAsync(Report report)
        {
            report.Timestamp = DateTime.UtcNow;
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task<LMPastValuation> CreateAsync(LMPastValuation lmPastValuation)
        {
            _context.LMPastValuations.Add(lmPastValuation);
            await _context.SaveChangesAsync();
            return lmPastValuation;
        }

        public async Task<bool> UpdateAsync(LMPastValuation lmPastValuation)
        {
            try
            {
                _context.Entry(lmPastValuation).State = EntityState.Modified;
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
            var lmPastValuation = await _context.LMPastValuations.FindAsync(id);
            if (lmPastValuation == null)
            {
                return false;
            }

            var report = await _context.Reports.FindAsync(lmPastValuation.ReportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            _context.LMPastValuations.Remove(lmPastValuation);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int reportId)
        {
            return await _context.LMPastValuations.AnyAsync(e => e.ReportId == reportId);
        }
    }
}
