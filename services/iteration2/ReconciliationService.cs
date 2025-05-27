using ValuationBackend.Models;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class ReconciliationService : IReconciliationService
    {
        private readonly IReconciliationRepository _repository;

        public ReconciliationService(IReconciliationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Reconciliation>> GetAllReconciliationsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Reconciliation?> GetReconciliationByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID must be a positive number", nameof(id));

            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Reconciliation>> GetReconciliationsByAssetIdAsync(int assetId)
        {
            if (assetId <= 0)
                throw new ArgumentException("Asset ID must be a positive number", nameof(assetId));

            return await _repository.GetByAssetIdAsync(assetId);
        }

        public async Task<List<Reconciliation>> GetReconciliationsByStreetNameAsync(string streetName)
        {
            if (string.IsNullOrWhiteSpace(streetName))
                throw new ArgumentException("Street name cannot be empty", nameof(streetName));

            return await _repository.GetByStreetNameAsync(streetName);
        }

        public async Task<List<Reconciliation>> GetReconciliationsByObsoleteNoAsync(string obsoleteNo)
        {
            if (string.IsNullOrWhiteSpace(obsoleteNo))
                throw new ArgumentException("Obsolete number cannot be empty", nameof(obsoleteNo));

            return await _repository.GetByObsoleteNoAsync(obsoleteNo);
        }

        public async Task<List<Reconciliation>> GetReconciliationsByNewNoAsync(string newNo)
        {
            if (string.IsNullOrWhiteSpace(newNo))
                throw new ArgumentException("New number cannot be empty", nameof(newNo));

            return await _repository.GetByNewNoAsync(newNo);
        }

        public async Task<Reconciliation> CreateReconciliationAsync(Reconciliation reconciliation)
        {
            if (reconciliation == null)
                throw new ArgumentNullException(nameof(reconciliation));

            ValidateReconciliation(reconciliation);

            return await _repository.CreateAsync(reconciliation);
        }

        public async Task<Reconciliation> UpdateReconciliationAsync(int id, Reconciliation reconciliation)
        {
            if (reconciliation == null)
                throw new ArgumentNullException(nameof(reconciliation));

            if (id != reconciliation.Id)
                throw new ArgumentException("ID mismatch", nameof(id));

            if (!await _repository.ExistsAsync(id))
                throw new InvalidOperationException($"Reconciliation with ID {id} does not exist");

            ValidateReconciliation(reconciliation);

            return await _repository.UpdateAsync(reconciliation);
        }

        public async Task<bool> DeleteReconciliationAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID must be a positive number", nameof(id));

            return await _repository.DeleteAsync(id);
        }

        public async Task<bool> ReconciliationExistsAsync(int id)
        {
            if (id <= 0)
                return false;

            return await _repository.ExistsAsync(id);
        }

        private static void ValidateReconciliation(Reconciliation reconciliation)
        {
            if (reconciliation.AssetId <= 0)
                throw new ArgumentException("Asset ID must be a positive number", nameof(reconciliation));

            if (string.IsNullOrWhiteSpace(reconciliation.StreetName))
                throw new ArgumentException("Street name is required", nameof(reconciliation));

            if (string.IsNullOrWhiteSpace(reconciliation.ObsoleteNo))
                throw new ArgumentException("Obsolete number is required", nameof(reconciliation));

            if (string.IsNullOrWhiteSpace(reconciliation.NewNo))
                throw new ArgumentException("New number is required", nameof(reconciliation));
        }
    }
}
