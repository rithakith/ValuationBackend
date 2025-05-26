using ValuationBackend.Models;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;

        public AssetService(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public List<Asset> GetAllAssets()
        {
            return _assetRepository.GetAll();
        }

        public Asset? GetAssetById(int id)
        {
            return _assetRepository.GetById(id);
        }

        public List<Asset> GetAssetsByRequestId(int requestId)
        {
            return _assetRepository.GetByRequestId(requestId);
        }

        public List<Asset> GetAssetsByAssetNo(string assetNo)
        {
            if (string.IsNullOrWhiteSpace(assetNo))
                return new List<Asset>();
            
            return _assetRepository.GetByAssetNo(assetNo);
        }

        public List<Asset> GetAssetsByPropertyType(PropertyType propertyType)
        {
            return _assetRepository.GetByPropertyType(propertyType);
        }

        public List<Asset> GetAssetsByWard(string ward)
        {
            if (string.IsNullOrWhiteSpace(ward))
                return new List<Asset>();
            
            return _assetRepository.GetByWard(ward);
        }

        public List<Asset> GetAssetsByOwner(string owner)
        {
            if (string.IsNullOrWhiteSpace(owner))
                return new List<Asset>();
            
            return _assetRepository.GetByOwner(owner);
        }

        public List<Asset> GetAssetsByRatingCard(bool isRatingCard)
        {
            return _assetRepository.GetByRatingCard(isRatingCard);
        }

        public Asset CreateAsset(Asset asset)
        {
            if (asset == null)
                throw new ArgumentNullException(nameof(asset));

            // Validate required fields
            if (string.IsNullOrWhiteSpace(asset.AssetNo))
                throw new ArgumentException("Asset number is required", nameof(asset));
            
            if (string.IsNullOrWhiteSpace(asset.Ward))
                throw new ArgumentException("Ward is required", nameof(asset));
            
            if (string.IsNullOrWhiteSpace(asset.RdSt))
                throw new ArgumentException("Rd/St is required", nameof(asset));
            
            if (string.IsNullOrWhiteSpace(asset.Owner))
                throw new ArgumentException("Owner is required", nameof(asset));

            return _assetRepository.Create(asset);
        }

        public Asset UpdateAsset(Asset asset)
        {
            if (asset == null)
                throw new ArgumentNullException(nameof(asset));

            if (!_assetRepository.Exists(asset.Id))
                throw new InvalidOperationException($"Asset with ID {asset.Id} does not exist");

            // Validate required fields
            if (string.IsNullOrWhiteSpace(asset.AssetNo))
                throw new ArgumentException("Asset number is required", nameof(asset));
            
            if (string.IsNullOrWhiteSpace(asset.Ward))
                throw new ArgumentException("Ward is required", nameof(asset));
            
            if (string.IsNullOrWhiteSpace(asset.RdSt))
                throw new ArgumentException("Rd/St is required", nameof(asset));
            
            if (string.IsNullOrWhiteSpace(asset.Owner))
                throw new ArgumentException("Owner is required", nameof(asset));

            return _assetRepository.Update(asset);
        }

        public bool DeleteAsset(int id)
        {
            if (id <= 0)
                return false;

            return _assetRepository.Delete(id);
        }

        public bool AssetExists(int id)
        {
            return _assetRepository.Exists(id);
        }
    }
}
