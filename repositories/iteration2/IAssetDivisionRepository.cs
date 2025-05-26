using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface IAssetDivisionRepository
    {
        Task<List<AssetDivision>> GetAllAsync();
        Task<AssetDivision?> GetByIdAsync(int id);
        Task<List<AssetDivision>> GetByAssetIdAsync(int assetId);
        Task<List<AssetDivision>> GetByNewAssetNoAsync(string newAssetNo);
        Task<AssetDivision> CreateAsync(AssetDivision division);
        Task<AssetDivision> UpdateAsync(AssetDivision division);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
