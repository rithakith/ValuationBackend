using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class LandMiscellaneousRepository : ILandMiscellaneousRepository
    {
        private readonly AppDbContext _context;

        public LandMiscellaneousRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<LandMiscellaneousMasterFile>> GetAllAsync()
        {
            return await _context.LandMiscellaneousMasterFiles.ToListAsync();
        }

        public async Task<List<LandMiscellaneousMasterFile>> GetPaginatedAsync(int pageNumber, int pageSize)
        {
            return await _context.LandMiscellaneousMasterFiles
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.LandMiscellaneousMasterFiles.CountAsync();
        }
        public async Task<List<LandMiscellaneousMasterFile>> SearchAsync(string searchTerm, int pageNumber, int pageSize)
        {
            var query = _context.LandMiscellaneousMasterFiles.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                // Convert searchTerm to lowercase for case-insensitive search
                var lowerSearchTerm = searchTerm.ToLower();

                // Check if searchTerm is numeric for MasterFileNo search
                bool isNumeric = int.TryParse(searchTerm, out int masterFileNo);

                query = query.Where(l =>
                    (isNumeric && l.MasterFileNo == masterFileNo) ||
                    l.PlanType.ToLower().Contains(lowerSearchTerm) ||
                    l.PlanNo.ToLower().Contains(lowerSearchTerm) ||
                    l.RequestingAuthorityReferenceNo.ToLower().Contains(lowerSearchTerm) ||
                    l.Status.ToLower().Contains(lowerSearchTerm) ||
                    l.MasterFileNo.ToString().Contains(searchTerm)
                );
            }

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<int> GetSearchCountAsync(string searchTerm)
        {
            var query = _context.LandMiscellaneousMasterFiles.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                // Convert searchTerm to lowercase for case-insensitive search
                var lowerSearchTerm = searchTerm.ToLower();

                // Check if searchTerm is numeric for MasterFileNo search
                bool isNumeric = int.TryParse(searchTerm, out int masterFileNo);

                query = query.Where(l =>
                    (isNumeric && l.MasterFileNo == masterFileNo) ||
                    l.PlanType.ToLower().Contains(lowerSearchTerm) ||
                    l.PlanNo.ToLower().Contains(lowerSearchTerm) ||
                    l.RequestingAuthorityReferenceNo.ToLower().Contains(lowerSearchTerm) ||
                    l.Status.ToLower().Contains(lowerSearchTerm) ||
                    l.MasterFileNo.ToString().Contains(searchTerm)
                );
            }

            return await query.CountAsync();
        }
    }
}
