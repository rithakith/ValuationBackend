using ValuationBackend.Models;

namespace ValuationBackend.Services
{
    public interface IAssetDivisionService
    {
        Task<List<AssetDivision>> GetAllAssetDivisionsAsync();
        Task<AssetDivision?> GetAssetDivisionByIdAsync(int id);
        Task<List<AssetDivision>> GetAssetDivisionsByAssetIdAsync(int assetId);
        Task<List<AssetDivision>> GetAssetDivisionsByNewAssetNoAsync(string newAssetNo);
        Task<AssetDivision> CreateAssetDivisionAsync(AssetDivision division);
        Task<AssetDivision> UpdateAssetDivisionAsync(int id, AssetDivision division);
        Task<bool> DeleteAssetDivisionAsync(int id);
        Task<bool> AssetDivisionExistsAsync(int id);
    }
}
