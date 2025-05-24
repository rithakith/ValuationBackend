// filepath: d:\Projects\vd\vd backend\ValuationBackend\services\IInspectionReportService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;

namespace ValuationBackend.Services
{
    public interface IInspectionReportService
    {
        Task<List<InspectionReportResponseDto>> GetAllAsync();
        Task<InspectionReportResponseDto> GetByIdAsync(int id);
        Task<InspectionReportResponseDto> GetByReportIdAsync(int reportId);
        Task<InspectionReportResponseDto> CreateAsync(InspectionReportCreateDto dto);
        Task<bool> UpdateAsync(int id, InspectionReportUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
