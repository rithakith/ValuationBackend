using Microsoft.EntityFrameworkCore;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class ReconciliationRepository : IReconciliationRepository
    {
        private readonly AppDbContext _context;

        public ReconciliationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reconciliation>> GetAllAsync()
        {
            return await _context.Reconciliations
                .Include(r => r.Asset)
                .OrderByDescending(r => r.UpdatedAt)
                .ToListAsync();
        }

        public async Task<Reconciliation?> GetByIdAsync(int id)
        {
            return await _context.Reconciliations
                .Include(r => r.Asset)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Reconciliation>> GetByAssetIdAsync(int assetId)
        {
            return await _context.Reconciliations
                .Include(r => r.Asset)
                .Where(r => r.AssetId == assetId)
                .OrderByDescending(r => r.UpdatedAt)
                .ToListAsync();
        }

        public async Task<List<Reconciliation>> GetByStreetNameAsync(string streetName)
        {
            return await _context.Reconciliations
                .Include(r => r.Asset)
                .Where(r => r.StreetName.Contains(streetName))
                .OrderByDescending(r => r.UpdatedAt)
                .ToListAsync();
        }

        public async Task<List<Reconciliation>> GetByObsoleteNoAsync(string obsoleteNo)
        {
            return await _context.Reconciliations
                .Include(r => r.Asset)
                .Where(r => r.ObsoleteNo == obsoleteNo)
                .OrderByDescending(r => r.UpdatedAt)
                .ToListAsync();
        }

        public async Task<List<Reconciliation>> GetByNewNoAsync(string newNo)
        {
            return await _context.Reconciliations
                .Include(r => r.Asset)
                .Where(r => r.NewNo == newNo)
                .OrderByDescending(r => r.UpdatedAt)
                .ToListAsync();
        }

        public async Task<Reconciliation> CreateAsync(Reconciliation reconciliation)
        {
            reconciliation.UpdatedAt = DateTime.UtcNow;
            _context.Reconciliations.Add(reconciliation);
            await _context.SaveChangesAsync();
            return reconciliation;
        }

        public async Task<Reconciliation> UpdateAsync(Reconciliation reconciliation)
        {
            reconciliation.UpdatedAt = DateTime.UtcNow;
            _context.Entry(reconciliation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return reconciliation;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reconciliation = await _context.Reconciliations.FindAsync(id);
            if (reconciliation == null)
                return false;

            _context.Reconciliations.Remove(reconciliation);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Reconciliations.AnyAsync(r => r.Id == id);
        }
    }
}
