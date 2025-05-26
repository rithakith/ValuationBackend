// filepath: c:\Users\User\Desktop\ValuationBackend\repositories\iteration2\DomesticRatingCardRepository.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class DomesticRatingCardRepository : IDomesticRatingCardRepository
    {
        private readonly AppDbContext _context;

        public DomesticRatingCardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DomesticRatingCard>> GetAllAsync()
        {
            return await _context.DomesticRatingCards
                .Include(d => d.Asset)
                .ToListAsync();
        }

        public async Task<DomesticRatingCard> GetByIdAsync(int id)
        {
            return await _context.DomesticRatingCards
                .Include(d => d.Asset)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<DomesticRatingCard>> GetByAssetIdAsync(int assetId)
        {
            return await _context.DomesticRatingCards
                .Include(d => d.Asset)
                .Where(d => d.AssetId == assetId)
                .ToListAsync();
        }

        public async Task<DomesticRatingCard> CreateAsync(DomesticRatingCard domesticRatingCard)
        {
            // Fetch the related asset to auto-fill owner and description
            var asset = await _context.Assets.FindAsync(domesticRatingCard.AssetId);
            
            if (asset == null)
            {
                throw new Exception($"Asset with ID {domesticRatingCard.AssetId} not found.");
            }

            // Auto-fill owner and description from the asset
            domesticRatingCard.Owner = asset.Owner;
            domesticRatingCard.Description = asset.Description.ToString();
            
            // Generate new number if not provided
            if (string.IsNullOrEmpty(domesticRatingCard.NewNumber))
            {
                domesticRatingCard.NewNumber = await GenerateNewNumberAsync(domesticRatingCard.AssetId);
            }            // Set creation date
            domesticRatingCard.CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);

            _context.DomesticRatingCards.Add(domesticRatingCard);
            await _context.SaveChangesAsync();

            return domesticRatingCard;
        }

        public async Task<DomesticRatingCard> UpdateAsync(DomesticRatingCard domesticRatingCard)
        {
            var existingCard = await GetByIdAsync(domesticRatingCard.Id);
            
            if (existingCard == null)
            {
                throw new Exception($"Domestic Rating Card with ID {domesticRatingCard.Id} not found.");
            }

            // Keep the original NewNumber, Owner, and Description
            domesticRatingCard.NewNumber = existingCard.NewNumber;
            domesticRatingCard.Owner = existingCard.Owner;
            domesticRatingCard.Description = existingCard.Description;
            domesticRatingCard.CreatedAt = existingCard.CreatedAt;

            _context.Entry(existingCard).CurrentValues.SetValues(domesticRatingCard);
            await _context.SaveChangesAsync();

            return domesticRatingCard;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var domesticRatingCard = await _context.DomesticRatingCards.FindAsync(id);
            
            if (domesticRatingCard == null)
            {
                return false;
            }

            _context.DomesticRatingCards.Remove(domesticRatingCard);
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

            // Get the existing count of domestic rating cards for this asset
            var cardCount = await _context.DomesticRatingCards
                .Where(d => d.AssetId == assetId)
                .CountAsync();

            // Format: DRC-{AssetNo}-{Count+1}
            return $"DRC-{asset.AssetNo}-{cardCount + 1:D3}";
        }
    }
}