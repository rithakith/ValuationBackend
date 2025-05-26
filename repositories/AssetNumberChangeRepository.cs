using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class AssetNumberChangeRepository : IAssetNumberChangeRepository
    {
        private readonly AppDbContext _context;

        public AssetNumberChangeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AssetNumberChange>> GetAllAsync()
        {
            return await _context.AssetNumberChanges
                .OrderByDescending(a => a.DateOfChange)
                .ToListAsync();
        }

        public async Task<AssetNumberChange?> GetByIdAsync(int id)
        {
            return await _context.AssetNumberChanges.FindAsync(id);
        }

        public async Task<AssetNumberChange?> GetByOldAssetNoAsync(string oldAssetNo)
        {
            return await _context.AssetNumberChanges
                .FirstOrDefaultAsync(a => a.OldAssetNo == oldAssetNo);
        }

        public async Task<IEnumerable<AssetNumberChange>> GetByNewAssetNoAsync(string newAssetNo)
        {
            return await _context.AssetNumberChanges
                .Where(a => a.NewAssetNo == newAssetNo)
                .OrderByDescending(a => a.DateOfChange)
                .ToListAsync();
        }

        public async Task<AssetNumberChange> CreateAsync(AssetNumberChange assetNumberChange)
        {
            _context.AssetNumberChanges.Add(assetNumberChange);
            await _context.SaveChangesAsync();
            return assetNumberChange;
        }

        public async Task<AssetNumberChange> UpdateAsync(AssetNumberChange assetNumberChange)
        {
            _context.Entry(assetNumberChange).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return assetNumberChange;
        }

        public async Task DeleteAsync(int id)
        {
            var assetNumberChange = await _context.AssetNumberChanges.FindAsync(id);
            if (assetNumberChange != null)
            {
                _context.AssetNumberChanges.Remove(assetNumberChange);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.AssetNumberChanges.AnyAsync(a => a.Id == id);
        }
    }
}