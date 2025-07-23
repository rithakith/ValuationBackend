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
        Task<PastValuationsLACoordinate> CreateAsync(PastValuationsLACoordinate coordinate);
        Task<bool> UpdateAsync(PastValuationsLACoordinate coordinate);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> PastValuationExistsAsync(int pastValuationId);
    }

    // BuildingRatesLA Coordinate Repository
    public interface IBuildingRatesLACoordinateRepository
    {
        Task<IEnumerable<BuildingRatesLACoordinate>> GetAllAsync();
        Task<BuildingRatesLACoordinate> GetByIdAsync(int id);
        Task<IEnumerable<BuildingRatesLACoordinate>> GetByBuildingRateIdAsync(int buildingRateId);
        Task<BuildingRatesLACoordinate> CreateAsync(BuildingRatesLACoordinate coordinate);
        Task<bool> UpdateAsync(BuildingRatesLACoordinate coordinate);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> BuildingRateExistsAsync(int buildingRateId);
    }

    // SalesEvidenceLA Coordinate Repository
    public interface ISalesEvidenceLACoordinateRepository
    {
        Task<IEnumerable<SalesEvidenceLACoordinate>> GetAllAsync();
        Task<SalesEvidenceLACoordinate> GetByIdAsync(int id);
        Task<IEnumerable<SalesEvidenceLACoordinate>> GetBySalesEvidenceIdAsync(int salesEvidenceId);
        Task<SalesEvidenceLACoordinate> CreateAsync(SalesEvidenceLACoordinate coordinate);
        Task<bool> UpdateAsync(SalesEvidenceLACoordinate coordinate);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> SalesEvidenceExistsAsync(int salesEvidenceId);
    }

    // RentalEvidenceLA Coordinate Repository
    public interface IRentalEvidenceLACoordinateRepository
    {
        Task<IEnumerable<RentalEvidenceLACoordinate>> GetAllAsync();
        Task<RentalEvidenceLACoordinate> GetByIdAsync(int id);
        Task<IEnumerable<RentalEvidenceLACoordinate>> GetByRentalEvidenceIdAsync(int rentalEvidenceId);
        Task<RentalEvidenceLACoordinate> CreateAsync(RentalEvidenceLACoordinate coordinate);
        Task<bool> UpdateAsync(RentalEvidenceLACoordinate coordinate);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> RentalEvidenceExistsAsync(int rentalEvidenceId);
    }
}
