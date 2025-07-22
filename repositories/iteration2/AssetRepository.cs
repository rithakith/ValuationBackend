using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly AppDbContext _context;

        public AssetRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Asset> GetAll()
        {
            return _context.Assets.Include(a => a.Request).OrderBy(a => a.CreatedAt).ToList();
        }

        public Asset? GetById(int id)
        {
            return _context.Assets.Include(a => a.Request).FirstOrDefault(a => a.Id == id);
        }

        public List<Asset> GetByRequestId(int requestId)
        {
            return _context
                .Assets.Include(a => a.Request)
                .Where(a => a.RequestId == requestId)
                .OrderBy(a => a.AssetNo)
                .ToList();
        }

        public List<Asset> GetByAssetNo(string assetNo)
        {
            return _context
                .Assets.Include(a => a.Request)
                .Where(a => a.AssetNo.Contains(assetNo))
                .OrderBy(a => a.AssetNo)
                .ToList();
        }

        public List<Asset> GetByPropertyType(PropertyType propertyType)
        {
            return _context
                .Assets.Include(a => a.Request)
                .Where(a => a.Description == propertyType)
                .OrderBy(a => a.AssetNo)
                .ToList();
        }

        public List<Asset> GetByWard(string ward)
        {
            return _context
                .Assets.Include(a => a.Request)
                .Where(a => a.Ward.Contains(ward))
                .OrderBy(a => a.Ward)
                .ToList();
        }

        public List<Asset> GetByOwner(string owner)
        {
            return _context
                .Assets.Include(a => a.Request)
                .Where(a => a.Owner.Contains(owner))
                .OrderBy(a => a.Owner)
                .ToList();
        }

        public List<Asset> GetByRatingCard(bool isRatingCard)
        {
            return _context
                .Assets.Include(a => a.Request)
                .Where(a => a.IsRatingCard == isRatingCard)
                .OrderBy(a => a.AssetNo)
                .ToList();
        }

        public Asset Create(Asset asset)
        {
            asset.CreatedAt = DateTime.UtcNow;
            asset.UpdatedAt = DateTime.UtcNow;
            _context.Assets.Add(asset);
            _context.SaveChanges();
            return asset;
        }

        public Asset Update(Asset asset)
        {
            asset.UpdatedAt = DateTime.UtcNow;
            _context.Assets.Update(asset);
            _context.SaveChanges();
            return asset;
        }

        public async Task<Asset> UpdateAsync(Asset asset)
        {
            asset.UpdatedAt = DateTime.UtcNow;
            _context.Assets.Update(asset);
            await _context.SaveChangesAsync();
            return asset;
        }

        public bool Delete(int id)
        {
            var asset = _context.Assets.Find(id);
            if (asset == null)
                return false;

            _context.Assets.Remove(asset);
            _context.SaveChanges();
            return true;
        }

        public bool Exists(int id)
        {
            return _context.Assets.Any(a => a.Id == id);
        }
    }
}
