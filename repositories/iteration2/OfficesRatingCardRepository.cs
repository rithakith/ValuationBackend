using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ValuationBackend.Data;
using ValuationBackend.Models.iteration2.RatingCards;

namespace ValuationBackend.Repositories.iteration2
{
    public class OfficesRatingCardRepository : IOfficesRatingCardRepository
    {
        private readonly AppDbContext _context;

        public OfficesRatingCardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OfficesRatingCard>> GetAllAsync()
        {
            return await _context.OfficesRatingCards
                .Include(o => o.Asset)
                .ToListAsync();
        }

        public async Task<OfficesRatingCard?> GetByIdAsync(int id)
        {
            return await _context.OfficesRatingCards
                .Include(o => o.Asset)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<OfficesRatingCard?> GetByAssetIdAsync(int assetId)
        {
            return await _context.OfficesRatingCards
                .Include(o => o.Asset)
                .FirstOrDefaultAsync(o => o.AssetId == assetId);
        }

        public async Task<OfficesRatingCard> CreateAsync(OfficesRatingCard officesRatingCard)
        {
            // Ensure all DateTime values are in UTC
            officesRatingCard.CreatedAt = DateTime.UtcNow;
            
            // Set UpdatedBy to same as CreatedBy if not already set
            if (string.IsNullOrEmpty(officesRatingCard.UpdatedBy))
            {
                officesRatingCard.UpdatedBy = officesRatingCard.CreatedBy;
            }
            
            // Convert Date to UTC if it has a value
            if (officesRatingCard.Date.HasValue && officesRatingCard.Date.Value.Kind != DateTimeKind.Utc)
            {
                officesRatingCard.Date = DateTime.SpecifyKind(officesRatingCard.Date.Value, DateTimeKind.Utc);
            }
            
            _context.OfficesRatingCards.Add(officesRatingCard);
            await _context.SaveChangesAsync();
            return officesRatingCard;
        }

        public async Task<OfficesRatingCard> UpdateAsync(OfficesRatingCard officesRatingCard)
        {
            officesRatingCard.UpdatedAt = DateTime.UtcNow;
            _context.Entry(officesRatingCard).State = EntityState.Modified;
            
            // Don't update these fields
            _context.Entry(officesRatingCard).Property(x => x.CreatedAt).IsModified = false;
            _context.Entry(officesRatingCard).Property(x => x.CreatedBy).IsModified = false;
            _context.Entry(officesRatingCard).Property(x => x.AssetId).IsModified = false;
            
            await _context.SaveChangesAsync();
            return officesRatingCard;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var officesRatingCard = await _context.OfficesRatingCards.FindAsync(id);
            if (officesRatingCard == null)
                return false;

            _context.OfficesRatingCards.Remove(officesRatingCard);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.OfficesRatingCards.AnyAsync(o => o.Id == id);
        }

        public async Task<bool> ExistsByAssetIdAsync(int assetId)
        {
            return await _context.OfficesRatingCards.AnyAsync(o => o.AssetId == assetId);
        }
    }
}