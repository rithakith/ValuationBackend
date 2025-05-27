using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface ILandMiscellaneousRepository
    {
        // Add to ILandMiscellaneousRepository.cs
        Task<List<LandMiscellaneousMasterFile>> GetPaginatedAsync(int pageNumber, int pageSize, string sortBy = "");
        Task<int> GetTotalCountAsync();
        Task<List<LandMiscellaneousMasterFile>> GetAllAsync(string sortBy = "");

        Task<List<LandMiscellaneousMasterFile>> SearchAsync(string searchTerm, int pageNumber, int pageSize, string sortBy = "");
        Task<int> GetSearchCountAsync(string searchTerm);
    }
}
