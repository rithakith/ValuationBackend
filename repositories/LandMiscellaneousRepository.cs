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

        public async Task<LandMiscellaneousMasterFile?> GetByIdAsync(int id)
        {
            return await _context.LandMiscellaneousMasterFiles.FindAsync(id);
        }

        public async Task<List<LandMiscellaneousMasterFile>> SearchByMasterFileNoAsync(int masterFileNo)
        {
            return await _context.LandMiscellaneousMasterFiles
                .Where(l => l.MasterFileNo == masterFileNo)
                .ToListAsync();
        }
    }
}
