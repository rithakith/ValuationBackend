using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class LMSalesEvidenceRepository : ILMSalesEvidenceRepository
    {
        private readonly AppDbContext _context;

        public LMSalesEvidenceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LMSalesEvidence>> GetAllAsync()
        {
            return await _context.LMSalesEvidences.ToListAsync();
        }

        public async Task<LMSalesEvidence> GetByIdAsync(int id)
        {
            return await _context.LMSalesEvidences.FindAsync(id);
        }

        public async Task<LMSalesEvidence> GetByIdWithMasterFileAsync(int id)
        {
            return await _context.LMSalesEvidences
                .Include(se => se.LandMiscellaneousMasterFile)
                .FirstOrDefaultAsync(se => se.Id == id);
        }

        public async Task<IEnumerable<LMSalesEvidence>> GetByMasterFileIdAsync(int masterFileId)
        {
            return await _context.LMSalesEvidences
                .Where(se => se.LandMiscellaneousMasterFileId == masterFileId)
                .Include(se => se.LandMiscellaneousMasterFile)
                .ToListAsync();
        }

        public async Task<LMSalesEvidence> GetByReportIdAsync(int reportId)
        {
            return await _context.LMSalesEvidences
                .FirstOrDefaultAsync(se => se.ReportId == reportId);
        }

        public async Task<Report> CreateReportAsync(Report report)
        {
            report.Timestamp = DateTime.UtcNow;
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task<LMSalesEvidence> CreateAsync(LMSalesEvidence lmSalesEvidence)
        {
            _context.LMSalesEvidences.Add(lmSalesEvidence);
            await _context.SaveChangesAsync();
            return lmSalesEvidence;
        }

        public async Task<bool> UpdateAsync(LMSalesEvidence lmSalesEvidence)
        {
            try
            {
                _context.Entry(lmSalesEvidence).State = EntityState.Modified;
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
            var lmSalesEvidence = await _context.LMSalesEvidences.FindAsync(id);
            if (lmSalesEvidence == null)
            {
                return false;
            }

            var report = await _context.Reports.FindAsync(lmSalesEvidence.ReportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            _context.LMSalesEvidences.Remove(lmSalesEvidence);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int reportId)
        {
            return await _context.LMSalesEvidences.AnyAsync(e => e.ReportId == reportId);
        }
    }
}
