using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class PastValuationsLARepository : IPastValuationsLARepository
    {
        private readonly AppDbContext _context;

        public PastValuationsLARepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PastValuationsLA>> GetAllAsync()
        {
            return await _context.PastValuationsLA
                .Include(p => p.Report)
                .ToListAsync();
        }

        public async Task<PastValuationsLA?> GetByIdAsync(int id)
        {
            return await _context.PastValuationsLA
                .Include(p => p.Report)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PastValuationsLA?> GetByReportIdAsync(int reportId)
        {
            return await _context.PastValuationsLA
                .Include(p => p.Report)
                .FirstOrDefaultAsync(p => p.ReportId == reportId);
        }

        public async Task<PastValuationsLA> CreateAsync(PastValuationsLA pastValuation, Report report)
        {
            pastValuation.Report = report;
            pastValuation.ReportId = report.ReportId;

            await _context.PastValuationsLA.AddAsync(pastValuation);
            await _context.SaveChangesAsync();
            return pastValuation;
        }

        public async Task UpdateAsync(PastValuationsLA pastValuation)
        {
            _context.PastValuationsLA.Update(pastValuation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(PastValuationsLA pastValuation)
        {
            _context.PastValuationsLA.Remove(pastValuation);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.PastValuationsLA.AnyAsync(e => e.Id == id);
        }
    }
}
