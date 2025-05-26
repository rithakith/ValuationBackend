using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class AssetNumberChangeService : IAssetNumberChangeService
    {
        private readonly IAssetNumberChangeRepository _repository;

        public AssetNumberChangeService(IAssetNumberChangeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AssetNumberChange>> GetAllAssetNumberChangesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<AssetNumberChange?> GetAssetNumberChangeByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<AssetNumberChange?> GetByOldAssetNoAsync(string oldAssetNo)
        {
            return await _repository.GetByOldAssetNoAsync(oldAssetNo);
        }

        public async Task<IEnumerable<AssetNumberChange>> GetByNewAssetNoAsync(string newAssetNo)
        {
            return await _repository.GetByNewAssetNoAsync(newAssetNo);
        }

        public async Task<AssetNumberChange> CreateAssetNumberChangeAsync(AssetNumberChange assetNumberChange)
        {
            // Set default values if not provided
            assetNumberChange.DateOfChange = DateTime.UtcNow;
            if (assetNumberChange.ChangedDate == null)
            {
                assetNumberChange.ChangedDate = DateTime.UtcNow;
            }

            return await _repository.CreateAsync(assetNumberChange);
        }

        public async Task<AssetNumberChange> UpdateAssetNumberChangeAsync(int id, AssetNumberChange assetNumberChange)
        {
            if (!await _repository.ExistsAsync(id))
            {
                throw new KeyNotFoundException($"Asset number change with ID {id} not found.");
            }

            assetNumberChange.Id = id;
            return await _repository.UpdateAsync(assetNumberChange);
        }

        public async Task DeleteAssetNumberChangeAsync(int id)
        {
            if (!await _repository.ExistsAsync(id))
            {
                throw new KeyNotFoundException($"Asset number change with ID {id} not found.");
            }

            await _repository.DeleteAsync(id);
        }
    }
}