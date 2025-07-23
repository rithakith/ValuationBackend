using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface ILALotRepository
    {
        Task<IEnumerable<LALot>> GetAllAsync();
        Task<LALot> GetByIdAsync(int id);
        Task<IEnumerable<LALot>> GetByMasterFileIdAsync(int masterFileId);
        Task<LALot> CreateAsync(LALot laLot);
        Task<bool> UpdateAsync(LALot laLot);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> MasterFileExistsAsync(int masterFileId);
    }
}
