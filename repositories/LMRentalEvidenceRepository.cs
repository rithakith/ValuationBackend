using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class LMRentalEvidenceRepository : ILMRentalEvidenceRepository
    {
        private readonly AppDbContext _context;

        public LMRentalEvidenceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LMRentalEvidence>> GetAllAsync()
        {
            return await _context.LMRentalEvidences.ToListAsync();
        }

        public async Task<LMRentalEvidence> GetByIdAsync(int id)
        {
            return await _context.LMRentalEvidences.FindAsync(id);
        }

        public async Task<LMRentalEvidence> GetByReportIdAsync(int reportId)
        {
            return await _context.LMRentalEvidences
                .FirstOrDefaultAsync(re => re.ReportId == reportId);
        }

        public async Task<Report> CreateReportAsync(Report report)
        {
            report.Timestamp = DateTime.UtcNow;
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task<LMRentalEvidence> CreateAsync(LMRentalEvidence lmRentalEvidence)
        {
            _context.LMRentalEvidences.Add(lmRentalEvidence);
            await _context.SaveChangesAsync();
            return lmRentalEvidence;
        }

        public async Task<bool> UpdateAsync(LMRentalEvidence lmRentalEvidence)
        {
            try
            {
                _context.Entry(lmRentalEvidence).State = EntityState.Modified;
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
            var lmRentalEvidence = await _context.LMRentalEvidences.FindAsync(id);
            if (lmRentalEvidence == null)
            {
                return false;
            }

            var report = await _context.Reports.FindAsync(lmRentalEvidence.ReportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            _context.LMRentalEvidences.Remove(lmRentalEvidence);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int reportId)
        {
            return await _context.LMRentalEvidences.AnyAsync(e => e.ReportId == reportId);
        }
    }
}
