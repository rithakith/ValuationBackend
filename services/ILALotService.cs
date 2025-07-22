using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;

namespace ValuationBackend.Services
{
    public interface ILALotService
    {
        Task<IEnumerable<LALotResponseDto>> GetAllAsync();
        Task<LALotResponseDto> GetByIdAsync(int id);
        Task<IEnumerable<LALotResponseDto>> GetByMasterFileIdAsync(int masterFileId);
        Task<LALotResponseDto> CreateAsync(LALotCreateDto dto);
        Task<LALotResponseDto> UpdateAsync(int id, LALotUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
