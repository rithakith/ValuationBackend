using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ValuationBackend.Data;
using ValuationBackend.Models;
using ValuationBackend.Models.iteration2;

namespace ValuationBackend.Repositories.iteration2
{
    public interface II2RentalEvidenceRepository
    {
        Task<I2RentalEvidence> GetByIdAsync(int id);
        Task<IEnumerable<I2RentalEvidence>> GetByAssetIdAsync(int assetId);
        Task<IEnumerable<I2RentalEvidence>> GetAllAsync();
        Task<I2RentalEvidence> CreateAsync(I2RentalEvidence rentalEvidence);
        Task<I2RentalEvidence> UpdateAsync(I2RentalEvidence rentalEvidence);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<int?> GetAnyAssetIdAsync();
        Task<int> CreateDummyAssetAsync();
    }

    public class I2RentalEvidenceRepository : II2RentalEvidenceRepository
    {
        private readonly AppDbContext _context;

        public I2RentalEvidenceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<I2RentalEvidence> GetByIdAsync(int id)
        {
            return await _context.I2RentalEvidences
                .Include(re => re.Asset)
                .FirstOrDefaultAsync(re => re.Id == id && !re.IsDeleted);
        }

        public async Task<IEnumerable<I2RentalEvidence>> GetByAssetIdAsync(int assetId)
        {
            return await _context.I2RentalEvidences
                .Include(re => re.Asset)
                .Where(re => re.AssetId == assetId && !re.IsDeleted)
                .OrderByDescending(re => re.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<I2RentalEvidence>> GetAllAsync()
        {
            return await _context.I2RentalEvidences
                .Include(re => re.Asset)
                .Where(re => !re.IsDeleted)
                .OrderByDescending(re => re.CreatedAt)
                .ToListAsync();
        }

        public async Task<I2RentalEvidence> CreateAsync(I2RentalEvidence rentalEvidence)
        {
            rentalEvidence.CreatedAt = DateTime.UtcNow;
            _context.I2RentalEvidences.Add(rentalEvidence);
            await _context.SaveChangesAsync();
            return rentalEvidence;
        }

        public async Task<I2RentalEvidence> UpdateAsync(I2RentalEvidence rentalEvidence)
        {
            rentalEvidence.UpdatedAt = DateTime.UtcNow;
            _context.Entry(rentalEvidence).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return rentalEvidence;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rentalEvidence = await _context.I2RentalEvidences.FindAsync(id);
            if (rentalEvidence == null)
                return false;

            rentalEvidence.IsDeleted = true;
            rentalEvidence.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.I2RentalEvidences
                .AnyAsync(re => re.Id == id && !re.IsDeleted);
        }

        public async Task<int?> GetAnyAssetIdAsync()
        {
            var asset = await _context.Assets
                .Select(a => (int?)a.Id)
                .FirstOrDefaultAsync();
            return asset;
        }

        public async Task<int> CreateDummyAssetAsync()
        {
            // First check if we have any request, if not create one
            var requestId = await _context.Requests.Select(r => (int?)r.Id).FirstOrDefaultAsync();
            if (!requestId.HasValue)
            {
                // Create a dummy request first
                var dummyRequest = new Request
                {
                    RatingReferenceNo = $"DUMMY-REQ-{DateTime.UtcNow:yyyyMMddHHmmss}",
                    RequestTypeId = 1, // Assuming 1 exists or we'll need to create that too
                    LocalAuthority = "Unknown",
                    YearOfRevision = DateTime.UtcNow.Year,
                    Status = true, // true = success
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                _context.Requests.Add(dummyRequest);
                await _context.SaveChangesAsync();
                requestId = dummyRequest.Id;
            }

            var dummyAsset = new Asset
            {
                AssetNo = $"DUMMY-{DateTime.UtcNow:yyyyMMddHHmmss}",
                Description = PropertyType.CommercialProperty, // Using CommercialProperty as default
                Owner = "System Generated",
                RequestId = requestId.Value,
                Ward = "Unknown",
                RdSt = "Unknown",
                IsRatingCard = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Assets.Add(dummyAsset);
            await _context.SaveChangesAsync();
            return dummyAsset.Id;
        }
    }
}