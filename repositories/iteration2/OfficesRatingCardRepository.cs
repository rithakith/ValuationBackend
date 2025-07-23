using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class OfficesRatingCardRepository : IOfficesRatingCardRepository
    {
        private readonly AppDbContext _context;

        public OfficesRatingCardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<OfficesRatingCard>> GetAllAsync()
        {
            return await _context.OfficesRatingCards
                .Include(o => o.Asset)
                .ToListAsync();
        }

        public async Task<OfficesRatingCard> GetByIdAsync(int id)
        {
            return await _context.OfficesRatingCards
                .Include(o => o.Asset)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<OfficesRatingCard>> GetByAssetIdAsync(int assetId)
        {
            return await _context.OfficesRatingCards
                .Include(o => o.Asset)
                .Where(o => o.AssetId == assetId)
                .ToListAsync();
        }

        public async Task<OfficesRatingCard> CreateAsync(OfficesRatingCard officesRatingCard)
        {
            // Fetch the related asset to auto-fill owner and description
            var asset = await _context.Assets.FindAsync(officesRatingCard.AssetId);
            
            if (asset == null)
            {
                throw new Exception($"Asset with ID {officesRatingCard.AssetId} not found.");
            }

            // Auto-fill owner and description from the asset
            officesRatingCard.Owner = asset.Owner;
            officesRatingCard.Description = asset.Description.ToString();
            
            // Generate new number if not provided
            if (string.IsNullOrEmpty(officesRatingCard.NewNumber))
            {
                officesRatingCard.NewNumber = await GenerateNewNumberAsync(officesRatingCard.AssetId);
            }

            // Set creation date
            officesRatingCard.CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);

            _context.OfficesRatingCards.Add(officesRatingCard);
            await _context.SaveChangesAsync();

            return officesRatingCard;
        }

        public async Task<OfficesRatingCard> UpdateAsync(OfficesRatingCard officesRatingCard)
        {
            var existingCard = await GetByIdAsync(officesRatingCard.Id);
            
            if (existingCard == null)
            {
                throw new Exception($"Offices Rating Card with ID {officesRatingCard.Id} not found.");
            }

            // Keep the original NewNumber, Owner, and Description
            officesRatingCard.NewNumber = existingCard.NewNumber;
            officesRatingCard.Owner = existingCard.Owner;
            officesRatingCard.Description = existingCard.Description;
            officesRatingCard.CreatedAt = existingCard.CreatedAt;

            _context.Entry(existingCard).CurrentValues.SetValues(officesRatingCard);
            await _context.SaveChangesAsync();

            return officesRatingCard;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var officesRatingCard = await _context.OfficesRatingCards.FindAsync(id);
            
            if (officesRatingCard == null)
            {
                return false;
            }

            _context.OfficesRatingCards.Remove(officesRatingCard);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<string> GenerateNewNumberAsync(int assetId)
        {
            var asset = await _context.Assets.FindAsync(assetId);
            
            if (asset == null)
            {
                throw new Exception($"Asset with ID {assetId} not found.");
            }

            // Get the existing count of offices rating cards for this asset
            var cardCount = await _context.OfficesRatingCards
                .Where(o => o.AssetId == assetId)
                .CountAsync();

            // Format: ORC-{AssetNo}-{Count+1}
            return $"ORC-{asset.AssetNo}-{cardCount + 1:D3}";
        }
    }
}