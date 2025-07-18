using ValuationBackend.Models;

namespace ValuationBackend.Services
{
    public interface IReconciliationService
    {
        Task<List<Reconciliation>> GetAllReconciliationsAsync();
        Task<Reconciliation?> GetReconciliationByIdAsync(int id);
        Task<List<Reconciliation>> GetReconciliationsByAssetIdAsync(int assetId);
        Task<List<Reconciliation>> GetReconciliationsByStreetNameAsync(string streetName);
        Task<List<Reconciliation>> GetReconciliationsByObsoleteNoAsync(string obsoleteNo);
        Task<List<Reconciliation>> GetReconciliationsByNewNoAsync(string newNo);
        Task<Reconciliation> CreateReconciliationAsync(Reconciliation reconciliation);
        Task<Reconciliation> UpdateReconciliationAsync(int id, Reconciliation reconciliation);
        Task<bool> DeleteReconciliationAsync(int id);
        Task<bool> ReconciliationExistsAsync(int id);
    }
}
