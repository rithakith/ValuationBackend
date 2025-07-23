using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class LALotRepository : ILALotRepository
    {
        private readonly AppDbContext _context;

        public LALotRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LALot>> GetAllAsync()
        {
            return await _context.LALots
                .Include(l => l.MasterFile)
                .ToListAsync();
        }

        public async Task<LALot> GetByIdAsync(int id)
        {
            return await _context.LALots
                .Include(l => l.MasterFile)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<LALot>> GetByMasterFileIdAsync(int masterFileId)
        {
            return await _context.LALots
                .Include(l => l.MasterFile)
                .Where(l => l.MasterFileId == masterFileId)
                .ToListAsync();
        }

        public async Task<LALot> CreateAsync(LALot laLot)
        {
            laLot.CreatedAt = DateTime.UtcNow;
            _context.LALots.Add(laLot);
            await _context.SaveChangesAsync();
            
            // Load the MasterFile for the response
            await _context.Entry(laLot)
                .Reference(l => l.MasterFile)
                .LoadAsync();
                
            return laLot;
        }

        public async Task<bool> UpdateAsync(LALot laLot)
        {
            try
            {
                laLot.UpdatedAt = DateTime.UtcNow;
                _context.Entry(laLot).State = EntityState.Modified;
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
            var laLot = await _context.LALots.FindAsync(id);
            if (laLot == null)
            {
                return false;
            }

            _context.LALots.Remove(laLot);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.LALots.AnyAsync(l => l.Id == id);
        }

        public async Task<bool> MasterFileExistsAsync(int masterFileId)
        {
            return await _context.LandAquisitionMasterFiles.AnyAsync(m => m.Id == masterFileId);
        }
    }
}
