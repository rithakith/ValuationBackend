using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class RentalEvidenceLARepository : IRentalEvidenceLARepository
    {
        private readonly AppDbContext _context;

        public RentalEvidenceLARepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RentalEvidenceLA>> GetAllAsync()
        {
            return await _context.RentalEvidencesLA
                .Include(r => r.Report)
                .ToListAsync();
        }

        public async Task<RentalEvidenceLA?> GetByIdAsync(int id)
        {
            return await _context.RentalEvidencesLA
                .Include(r => r.Report)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<RentalEvidenceLA?> GetByReportIdAsync(int reportId)
        {
            return await _context.RentalEvidencesLA
                .Include(r => r.Report)
                .FirstOrDefaultAsync(r => r.ReportId == reportId);
        }

        public async Task<RentalEvidenceLA> CreateAsync(RentalEvidenceLA rentalEvidence, Report report)
        {
            rentalEvidence.Report = report;
            rentalEvidence.ReportId = report.ReportId;

            await _context.RentalEvidencesLA.AddAsync(rentalEvidence);
            await _context.SaveChangesAsync();
            return rentalEvidence;
        }

        public async Task UpdateAsync(RentalEvidenceLA rentalEvidence)
        {
            _context.RentalEvidencesLA.Update(rentalEvidence);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RentalEvidenceLA rentalEvidence)
        {
            _context.RentalEvidencesLA.Remove(rentalEvidence);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.RentalEvidencesLA.AnyAsync(e => e.Id == id);
        }
    }
}
