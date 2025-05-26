using ValuationBackend.Models;

namespace ValuationBackend.Services
{
    public interface IAssetService
    {
        List<Asset> GetAllAssets();
        Asset? GetAssetById(int id);
        List<Asset> GetAssetsByRequestId(int requestId);
        List<Asset> GetAssetsByAssetNo(string assetNo);
        List<Asset> GetAssetsByPropertyType(PropertyType propertyType);
        List<Asset> GetAssetsByWard(string ward);
        List<Asset> GetAssetsByOwner(string owner);
        List<Asset> GetAssetsByRatingCard(bool isRatingCard);
        Asset CreateAsset(Asset asset);
        Asset UpdateAsset(Asset asset);
        bool DeleteAsset(int id);
        bool AssetExists(int id);
    }
}
