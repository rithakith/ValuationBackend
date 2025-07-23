using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    // PastValuationsLA Coordinate Repository
    public interface IPastValuationsLACoordinateRepository
    {
        Task<IEnumerable<PastValuationsLACoordinate>> GetAllAsync();
        Task<PastValuationsLACoordinate> GetByIdAsync(int id);
        Task<IEnumerable<PastValuationsLACoordinate>> GetByPastValuationIdAsync(int pastValuationId);
        Task<IEnumerable<PastValuationsLACoordinate>> GetByMasterfileIdAsync(int masterfileId);
        Task<PastValuationsLACoordinate> CreateAsync(PastValuationsLACoordinate coordinate);
        Task<bool> UpdateAsync(PastValuationsLACoordinate coordinate);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> PastValuationExistsAsync(int pastValuationId);
        Task<bool> MasterFileExistsAsync(int masterFileId);
    }

    // BuildingRatesLA Coordinate Repository
    public interface IBuildingRatesLACoordinateRepository
    {
        Task<IEnumerable<BuildingRatesLACoordinate>> GetAllAsync();
        Task<BuildingRatesLACoordinate> GetByIdAsync(int id);
        Task<IEnumerable<BuildingRatesLACoordinate>> GetByBuildingRateIdAsync(int buildingRateId);
        Task<IEnumerable<BuildingRatesLACoordinate>> GetByMasterfileIdAsync(int masterfileId);
        Task<BuildingRatesLACoordinate> CreateAsync(BuildingRatesLACoordinate coordinate);
        Task<bool> UpdateAsync(BuildingRatesLACoordinate coordinate);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> BuildingRateExistsAsync(int buildingRateId);
        Task<bool> MasterFileExistsAsync(int masterFileId);
    }

    // SalesEvidenceLA Coordinate Repository
    public interface ISalesEvidenceLACoordinateRepository
    {
        Task<IEnumerable<SalesEvidenceLACoordinate>> GetAllAsync();
        Task<SalesEvidenceLACoordinate> GetByIdAsync(int id);
        Task<IEnumerable<SalesEvidenceLACoordinate>> GetBySalesEvidenceIdAsync(int salesEvidenceId);
        Task<IEnumerable<SalesEvidenceLACoordinate>> GetByMasterfileIdAsync(int masterfileId);
        Task<SalesEvidenceLACoordinate> CreateAsync(SalesEvidenceLACoordinate coordinate);
        Task<bool> UpdateAsync(SalesEvidenceLACoordinate coordinate);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> SalesEvidenceExistsAsync(int salesEvidenceId);
        Task<bool> MasterFileExistsAsync(int masterFileId);
    }

    // RentalEvidenceLA Coordinate Repository
    public interface IRentalEvidenceLACoordinateRepository
    {
        Task<IEnumerable<RentalEvidenceLACoordinate>> GetAllAsync();
        Task<RentalEvidenceLACoordinate> GetByIdAsync(int id);
        Task<IEnumerable<RentalEvidenceLACoordinate>> GetByRentalEvidenceIdAsync(int rentalEvidenceId);
        Task<IEnumerable<RentalEvidenceLACoordinate>> GetByMasterfileIdAsync(int masterfileId);
        Task<RentalEvidenceLACoordinate> CreateAsync(RentalEvidenceLACoordinate coordinate);
        Task<bool> UpdateAsync(RentalEvidenceLACoordinate coordinate);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> RentalEvidenceExistsAsync(int rentalEvidenceId);
        Task<bool> MasterFileExistsAsync(int masterFileId);
    }
}
