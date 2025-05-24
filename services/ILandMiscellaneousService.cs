using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Services
{
    public interface ILandMiscellaneousService
    {
        Task<List<LandMiscellaneousMasterFile>> GetAllAsync();
        Task<LandMiscellaneousMasterFile?> GetByIdAsync(int id);
        Task<List<LandMiscellaneousMasterFile>> SearchByMasterFileNoAsync(int masterFileNo);
    }
}
