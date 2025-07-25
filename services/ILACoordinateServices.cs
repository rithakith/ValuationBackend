using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;

namespace ValuationBackend.Services
{
    // PastValuationsLA Coordinate Service
    public interface IPastValuationsLACoordinateService
    {
        Task<IEnumerable<PastValuationsLACoordinateResponseDto>> GetAllAsync();
        Task<PastValuationsLACoordinateResponseDto> GetByIdAsync(int id);
        Task<IEnumerable<PastValuationsLACoordinateResponseDto>> GetByPastValuationIdAsync(int pastValuationId);
        Task<IEnumerable<PastValuationsLACoordinateResponseDto>> GetByMasterfileIdAsync(int masterfileId);
        Task<PastValuationsLACoordinateResponseDto> CreateAsync(PastValuationsLACoordinateCreateDto dto);
        Task<PastValuationsLACoordinateResponseDto> UpdateAsync(int id, PastValuationsLACoordinateUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }

    // BuildingRatesLA Coordinate Service
    public interface IBuildingRatesLACoordinateService
    {
        Task<IEnumerable<BuildingRatesLACoordinateResponseDto>> GetAllAsync();
        Task<BuildingRatesLACoordinateResponseDto> GetByIdAsync(int id);
        Task<IEnumerable<BuildingRatesLACoordinateResponseDto>> GetByBuildingRateIdAsync(int buildingRateId);
        Task<IEnumerable<BuildingRatesLACoordinateResponseDto>> GetByMasterfileIdAsync(int masterfileId);
        Task<BuildingRatesLACoordinateResponseDto> CreateAsync(BuildingRatesLACoordinateCreateDto dto);
        Task<BuildingRatesLACoordinateResponseDto> UpdateAsync(int id, BuildingRatesLACoordinateUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }

    // SalesEvidenceLA Coordinate Service
    public interface ISalesEvidenceLACoordinateService
    {
        Task<IEnumerable<SalesEvidenceLACoordinateResponseDto>> GetAllAsync();
        Task<SalesEvidenceLACoordinateResponseDto> GetByIdAsync(int id);
        Task<IEnumerable<SalesEvidenceLACoordinateResponseDto>> GetBySalesEvidenceIdAsync(int salesEvidenceId);
        Task<IEnumerable<SalesEvidenceLACoordinateResponseDto>> GetByMasterfileIdAsync(int masterfileId);
        Task<SalesEvidenceLACoordinateResponseDto> CreateAsync(SalesEvidenceLACoordinateCreateDto dto);
        Task<SalesEvidenceLACoordinateResponseDto> UpdateAsync(int id, SalesEvidenceLACoordinateUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }

    // RentalEvidenceLA Coordinate Service
    public interface IRentalEvidenceLACoordinateService
    {
        Task<IEnumerable<RentalEvidenceLACoordinateResponseDto>> GetAllAsync();
        Task<RentalEvidenceLACoordinateResponseDto> GetByIdAsync(int id);
        Task<IEnumerable<RentalEvidenceLACoordinateResponseDto>> GetByRentalEvidenceIdAsync(int rentalEvidenceId);
        Task<IEnumerable<RentalEvidenceLACoordinateResponseDto>> GetByMasterfileIdAsync(int masterfileId);
        Task<RentalEvidenceLACoordinateResponseDto> CreateAsync(RentalEvidenceLACoordinateCreateDto dto);
        Task<RentalEvidenceLACoordinateResponseDto> UpdateAsync(int id, RentalEvidenceLACoordinateUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
