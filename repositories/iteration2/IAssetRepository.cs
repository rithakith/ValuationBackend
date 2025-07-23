using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface IAssetRepository
    {
        List<Asset> GetAll();
        Asset? GetById(int id);
        List<Asset> GetByRequestId(int requestId);
        List<Asset> GetByAssetNo(string assetNo);
        List<Asset> GetByPropertyType(PropertyType propertyType);
        List<Asset> GetByWard(string ward);
        List<Asset> GetByOwner(string owner);
        List<Asset> GetByRatingCard(bool isRatingCard);
        Asset Create(Asset asset);
        Asset Update(Asset asset);
        bool Delete(int id);
        bool Exists(int id);
        List<Asset> Search(int requestId, PropertyType requestType, string query);
        List<Asset> SearchAll(string query);
    }
}
