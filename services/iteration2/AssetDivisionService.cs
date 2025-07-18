using ValuationBackend.Models;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class AssetDivisionService : IAssetDivisionService
    {
        private readonly IAssetDivisionRepository _repository;

        public AssetDivisionService(IAssetDivisionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AssetDivision>> GetAllAssetDivisionsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<AssetDivision?> GetAssetDivisionByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<AssetDivision>> GetAssetDivisionsByAssetIdAsync(int assetId)
        {
            if (assetId <= 0)
                throw new ArgumentException("Asset ID must be a positive number", nameof(assetId));

            return await _repository.GetByAssetIdAsync(assetId);
        }

        public async Task<List<AssetDivision>> GetAssetDivisionsByNewAssetNoAsync(string newAssetNo)
        {
            if (string.IsNullOrWhiteSpace(newAssetNo))
                throw new ArgumentException("New asset number cannot be empty", nameof(newAssetNo));

            return await _repository.GetByNewAssetNoAsync(newAssetNo);
        }

        public async Task<AssetDivision> CreateAssetDivisionAsync(AssetDivision division)
        {
            if (division == null)
                throw new ArgumentNullException(nameof(division));

            ValidateAssetDivision(division);

            return await _repository.CreateAsync(division);
        }

        public async Task<AssetDivision> UpdateAssetDivisionAsync(int id, AssetDivision division)
        {
            if (division == null)
                throw new ArgumentNullException(nameof(division));

            if (id != division.Id)
                throw new ArgumentException("ID mismatch", nameof(id));

            if (!await _repository.ExistsAsync(id))
                throw new InvalidOperationException($"Asset division with ID {id} does not exist");

            ValidateAssetDivision(division);

            return await _repository.UpdateAsync(division);
        }

        public async Task<bool> DeleteAssetDivisionAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID must be a positive number", nameof(id));

            return await _repository.DeleteAsync(id);
        }

        public async Task<bool> AssetDivisionExistsAsync(int id)
        {
            if (id <= 0)
                return false;

            return await _repository.ExistsAsync(id);
        }

        private static void ValidateAssetDivision(AssetDivision division)
        {
            if (division.AssetId <= 0)
                throw new ArgumentException("Asset ID must be a positive number", nameof(division));

            if (string.IsNullOrWhiteSpace(division.NewAssetNo))
                throw new ArgumentException("New asset number is required", nameof(division));

            if (division.Area <= 0)
                throw new ArgumentException("Area must be a positive number", nameof(division));

            if (string.IsNullOrWhiteSpace(division.LandType))
                throw new ArgumentException("Land type is required", nameof(division));
        }
    }
}
