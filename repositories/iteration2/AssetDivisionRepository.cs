using Microsoft.EntityFrameworkCore;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class AssetDivisionRepository : IAssetDivisionRepository
    {
        private readonly AppDbContext _context;

        public AssetDivisionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AssetDivision>> GetAllAsync()
        {
            return await _context.AssetDivisions
                .Include(d => d.Asset)
                .OrderByDescending(d => d.CreatedAt)
                .ToListAsync();
        }

        public async Task<AssetDivision?> GetByIdAsync(int id)
        {
            return await _context.AssetDivisions
                .Include(d => d.Asset)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<AssetDivision>> GetByAssetIdAsync(int assetId)
        {
            return await _context.AssetDivisions
                .Include(d => d.Asset)
                .Where(d => d.AssetId == assetId)
                .OrderByDescending(d => d.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<AssetDivision>> GetByNewAssetNoAsync(string newAssetNo)
        {
            return await _context.AssetDivisions
                .Include(d => d.Asset)
                .Where(d => d.NewAssetNo.Contains(newAssetNo))
                .OrderByDescending(d => d.CreatedAt)
                .ToListAsync();
        }

        public async Task<AssetDivision> CreateAsync(AssetDivision division)
        {
            division.CreatedAt = DateTime.UtcNow;
            _context.AssetDivisions.Add(division);
            await _context.SaveChangesAsync();
            return division;
        }

        public async Task<AssetDivision> UpdateAsync(AssetDivision division)
        {
            _context.Entry(division).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return division;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var division = await _context.AssetDivisions.FindAsync(id);
            if (division == null)
                return false;

            _context.AssetDivisions.Remove(division);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.AssetDivisions.AnyAsync(d => d.Id == id);
        }
    }
}
