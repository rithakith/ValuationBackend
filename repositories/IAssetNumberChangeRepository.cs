using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface IAssetNumberChangeRepository
    {
        Task<IEnumerable<AssetNumberChange>> GetAllAsync();
        Task<AssetNumberChange?> GetByIdAsync(int id);
        Task<AssetNumberChange?> GetByOldAssetNoAsync(string oldAssetNo);
        Task<IEnumerable<AssetNumberChange>> GetByNewAssetNoAsync(string newAssetNo);
        Task<AssetNumberChange> CreateAsync(AssetNumberChange assetNumberChange);
        Task<AssetNumberChange> UpdateAsync(AssetNumberChange assetNumberChange);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}