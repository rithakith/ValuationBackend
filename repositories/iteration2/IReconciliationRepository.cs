using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface IReconciliationRepository
    {
        Task<List<Reconciliation>> GetAllAsync();
        Task<Reconciliation?> GetByIdAsync(int id);
        Task<List<Reconciliation>> GetByAssetIdAsync(int assetId);
        Task<List<Reconciliation>> GetByStreetNameAsync(string streetName);
        Task<List<Reconciliation>> GetByObsoleteNoAsync(string obsoleteNo);
        Task<List<Reconciliation>> GetByNewNoAsync(string newNo);
        Task<Reconciliation> CreateAsync(Reconciliation reconciliation);
        Task<Reconciliation> UpdateAsync(Reconciliation reconciliation);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
