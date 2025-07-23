using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface ILandMiscellaneousRepository
    {
        // Add to ILandMiscellaneousRepository.cs
        Task<List<LandMiscellaneousMasterFile>> GetPaginatedAsync(int pageNumber, int pageSize, string sortBy = "", int? assignedToUserId = null);
        Task<int> GetTotalCountAsync(int? assignedToUserId = null);
        Task<List<LandMiscellaneousMasterFile>> GetAllAsync(string sortBy = "", int? assignedToUserId = null);

        Task<List<LandMiscellaneousMasterFile>> SearchAsync(string searchTerm, int pageNumber, int pageSize, string sortBy = "", int? assignedToUserId = null);
        Task<int> GetSearchCountAsync(string searchTerm, int? assignedToUserId = null);

        // NEW: Method for foreign key support
        Task<LandMiscellaneousMasterFile?> GetByRefNoAsync(string refNo);
        Task<LandMiscellaneousMasterFile?> GetByIdAsync(int id);
    }
}
