using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface ILandMiscellaneousRepository
    {
        // Add to ILandMiscellaneousRepository.cs
        Task<List<LandMiscellaneousMasterFile>> GetPaginatedAsync(int pageNumber, int pageSize);
        Task<int> GetTotalCountAsync();
        Task<List<LandMiscellaneousMasterFile>> GetAllAsync();

        Task<List<LandMiscellaneousMasterFile>> SearchAsync(string searchTerm, int pageNumber, int pageSize);
        Task<int> GetSearchCountAsync(string searchTerm);
    }
}
