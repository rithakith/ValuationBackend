using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Services
{
    public interface ILandMiscellaneousService
    {
        Task<(List<LandMiscellaneousMasterFile> Records, int TotalCount)> GetPaginatedAsync(int pageNumber, int pageSize);
        Task<List<LandMiscellaneousMasterFile>> GetAllAsync();
        Task<(List<LandMiscellaneousMasterFile> Records, int TotalCount)> SearchAsync(string searchTerm, int pageNumber, int pageSize);
    }
}
