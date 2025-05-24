using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class SalesEvidenceLARepository : ISalesEvidenceLARepository
    {
        private readonly AppDbContext _context;

        public SalesEvidenceLARepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesEvidenceLA>> GetAllAsync()
        {
            return await _context.SalesEvidencesLA
                .Include(s => s.Report)
                .ToListAsync();
        }

        public async Task<SalesEvidenceLA?> GetByIdAsync(int id)
        {
            return await _context.SalesEvidencesLA
                .Include(s => s.Report)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<SalesEvidenceLA?> GetByReportIdAsync(int reportId)
        {
            return await _context.SalesEvidencesLA
                .Include(s => s.Report)
                .FirstOrDefaultAsync(s => s.ReportId == reportId);
        }

        public async Task<SalesEvidenceLA> CreateAsync(SalesEvidenceLA salesEvidence, Report report)
        {
            salesEvidence.Report = report;
            salesEvidence.ReportId = report.ReportId;

            await _context.SalesEvidencesLA.AddAsync(salesEvidence);
            await _context.SaveChangesAsync();
            return salesEvidence;
        }

        public async Task UpdateAsync(SalesEvidenceLA salesEvidence)
        {
            _context.SalesEvidencesLA.Update(salesEvidence);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(SalesEvidenceLA salesEvidence)
        {
            _context.SalesEvidencesLA.Remove(salesEvidence);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.SalesEvidencesLA.AnyAsync(e => e.Id == id);
        }
    }
}
