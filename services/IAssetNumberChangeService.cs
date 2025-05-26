using ValuationBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ValuationBackend.Services
{
    public interface IAssetNumberChangeService
    {
        Task<IEnumerable<AssetNumberChange>> GetAllAssetNumberChangesAsync();
        Task<AssetNumberChange?> GetAssetNumberChangeByIdAsync(int id);
        Task<AssetNumberChange?> GetByOldAssetNoAsync(string oldAssetNo);
        Task<IEnumerable<AssetNumberChange>> GetByNewAssetNoAsync(string newAssetNo);
        Task<AssetNumberChange> CreateAssetNumberChangeAsync(AssetNumberChange assetNumberChange);
        Task<AssetNumberChange> UpdateAssetNumberChangeAsync(int id, AssetNumberChange assetNumberChange);
        Task DeleteAssetNumberChangeAsync(int id);
    }
}