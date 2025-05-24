using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class ConditionReportRepository : IConditionReportRepository
    {
        private readonly AppDbContext _context;

        public ConditionReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ConditionReport>> GetAllAsync()
        {
            return await _context.ConditionReports.ToListAsync();
        }

        public async Task<ConditionReport> GetByIdAsync(int id)
        {
            return await _context.ConditionReports.FindAsync(id);
        }

        public async Task<ConditionReport> GetByReportIdAsync(int reportId)
        {
            return await _context.ConditionReports
                .FirstOrDefaultAsync(cr => cr.ReportId == reportId);
        }

        public async Task<Report> CreateReportAsync(Report report)
        {
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task<ConditionReport> CreateAsync(ConditionReport conditionReport)
        {
            _context.ConditionReports.Add(conditionReport);
            await _context.SaveChangesAsync();
            return conditionReport;
        }

        public async Task<bool> UpdateAsync(ConditionReport conditionReport)
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ExistsAsync(conditionReport.Id))
                {
                    return false;
                }
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var conditionReport = await GetByIdAsync(id);
            if (conditionReport == null)
            {
                return false;
            }

            // Delete associated report
            var report = await _context.Reports.FindAsync(conditionReport.ReportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            _context.ConditionReports.Remove(conditionReport);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.ConditionReports.AnyAsync(e => e.Id == id);
        }
    }
}
