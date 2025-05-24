using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;

namespace ValuationBackend.Services
{
    public interface IConditionReportService
    {
        Task<IEnumerable<ConditionReportResponseDto>> GetAllAsync();
        Task<ConditionReportResponseDto> GetByIdAsync(int id);
        Task<ConditionReportResponseDto> GetByReportIdAsync(int reportId);
        Task<ConditionReportResponseDto> CreateAsync(ConditionReportCreateDto dto);
        Task<bool> UpdateAsync(int id, ConditionReportUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
