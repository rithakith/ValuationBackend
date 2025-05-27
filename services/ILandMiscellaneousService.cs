using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Services
{
    public interface ILandMiscellaneousService
    {
        Task<(List<LandMiscellaneousMasterFile> Records, int TotalCount)> GetPaginatedAsync(int pageNumber, int pageSize, string sortBy = "");
        Task<List<LandMiscellaneousMasterFile>> GetAllAsync(string sortBy = "");
        Task<(List<LandMiscellaneousMasterFile> Records, int TotalCount)> SearchAsync(string searchTerm, int pageNumber, int pageSize, string sortBy = "");
    }
}
