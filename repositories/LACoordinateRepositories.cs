using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    // PastValuationsLA Coordinate Repository
    public class PastValuationsLACoordinateRepository : IPastValuationsLACoordinateRepository
    {
        private readonly AppDbContext _context;

        public PastValuationsLACoordinateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PastValuationsLACoordinate>> GetAllAsync()
        {
            return await _context.PastValuationsLACoordinates
                .Include(c => c.PastValuation)
                .Include(c => c.Masterfile)
                .ToListAsync();
        }

        public async Task<PastValuationsLACoordinate> GetByIdAsync(int id)
        {
            return await _context.PastValuationsLACoordinates
                .Include(c => c.PastValuation)
                .Include(c => c.Masterfile)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<PastValuationsLACoordinate>> GetByPastValuationIdAsync(int pastValuationId)
        {
            return await _context.PastValuationsLACoordinates
                .Include(c => c.PastValuation)
                .Include(c => c.Masterfile)
                .Where(c => c.PastValuationId == pastValuationId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PastValuationsLACoordinate>> GetByMasterfileIdAsync(int masterfileId)
        {
            return await _context.PastValuationsLACoordinates
                .Include(c => c.PastValuation)
                .Include(c => c.Masterfile)
                .Where(c => c.MasterfileId == masterfileId)
                .ToListAsync();
        }

        public async Task<PastValuationsLACoordinate> CreateAsync(PastValuationsLACoordinate coordinate)
        {
            coordinate.CreatedAt = DateTime.UtcNow;
            _context.PastValuationsLACoordinates.Add(coordinate);
            await _context.SaveChangesAsync();
            
            await _context.Entry(coordinate)
                .Reference(c => c.PastValuation)
                .LoadAsync();
                
            return coordinate;
        }

        public async Task<bool> UpdateAsync(PastValuationsLACoordinate coordinate)
        {
            try
            {
                coordinate.UpdatedAt = DateTime.UtcNow;
                _context.Entry(coordinate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var coordinate = await _context.PastValuationsLACoordinates.FindAsync(id);
            if (coordinate == null)
            {
                return false;
            }

            _context.PastValuationsLACoordinates.Remove(coordinate);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.PastValuationsLACoordinates.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> PastValuationExistsAsync(int pastValuationId)
        {
            return await _context.PastValuationsLA.AnyAsync(p => p.Id == pastValuationId);
        }

        public async Task<bool> MasterFileExistsAsync(int masterFileId)
        {
            return await _context.LandAquisitionMasterFiles.AnyAsync(m => m.Id == masterFileId);
        }
    }

    // BuildingRatesLA Coordinate Repository
    public class BuildingRatesLACoordinateRepository : IBuildingRatesLACoordinateRepository
    {
        private readonly AppDbContext _context;

        public BuildingRatesLACoordinateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BuildingRatesLACoordinate>> GetAllAsync()
        {
            return await _context.BuildingRatesLACoordinates
                .Include(c => c.BuildingRate)
                .Include(c => c.Masterfile)
                .ToListAsync();
        }

        public async Task<BuildingRatesLACoordinate> GetByIdAsync(int id)
        {
            return await _context.BuildingRatesLACoordinates
                .Include(c => c.BuildingRate)
                .Include(c => c.Masterfile)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<BuildingRatesLACoordinate>> GetByBuildingRateIdAsync(int buildingRateId)
        {
            return await _context.BuildingRatesLACoordinates
                .Include(c => c.BuildingRate)
                .Include(c => c.Masterfile)
                .Where(c => c.BuildingRateId == buildingRateId)
                .ToListAsync();
        }

        public async Task<IEnumerable<BuildingRatesLACoordinate>> GetByMasterfileIdAsync(int masterfileId)
        {
            return await _context.BuildingRatesLACoordinates
                .Include(c => c.BuildingRate)
                .Include(c => c.Masterfile)
                .Where(c => c.MasterfileId == masterfileId)
                .ToListAsync();
        }

        public async Task<BuildingRatesLACoordinate> CreateAsync(BuildingRatesLACoordinate coordinate)
        {
            coordinate.CreatedAt = DateTime.UtcNow;
            _context.BuildingRatesLACoordinates.Add(coordinate);
            await _context.SaveChangesAsync();
            
            await _context.Entry(coordinate)
                .Reference(c => c.BuildingRate)
                .LoadAsync();
                
            return coordinate;
        }

        public async Task<bool> UpdateAsync(BuildingRatesLACoordinate coordinate)
        {
            try
            {
                coordinate.UpdatedAt = DateTime.UtcNow;
                _context.Entry(coordinate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var coordinate = await _context.BuildingRatesLACoordinates.FindAsync(id);
            if (coordinate == null)
            {
                return false;
            }

            _context.BuildingRatesLACoordinates.Remove(coordinate);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.BuildingRatesLACoordinates.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> BuildingRateExistsAsync(int buildingRateId)
        {
            return await _context.BuildingRatesLA.AnyAsync(b => b.Id == buildingRateId);
        }

        public async Task<bool> MasterFileExistsAsync(int masterFileId)
        {
            return await _context.LandAquisitionMasterFiles.AnyAsync(m => m.Id == masterFileId);
        }
    }

    // SalesEvidenceLA Coordinate Repository
    public class SalesEvidenceLACoordinateRepository : ISalesEvidenceLACoordinateRepository
    {
        private readonly AppDbContext _context;

        public SalesEvidenceLACoordinateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesEvidenceLACoordinate>> GetAllAsync()
        {
            return await _context.SalesEvidenceLACoordinates
                .Include(c => c.SalesEvidence)
                .Include(c => c.Masterfile)
                .ToListAsync();
        }

        public async Task<SalesEvidenceLACoordinate> GetByIdAsync(int id)
        {
            return await _context.SalesEvidenceLACoordinates
                .Include(c => c.SalesEvidence)
                .Include(c => c.Masterfile)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<SalesEvidenceLACoordinate>> GetBySalesEvidenceIdAsync(int salesEvidenceId)
        {
            return await _context.SalesEvidenceLACoordinates
                .Include(c => c.SalesEvidence)
                .Include(c => c.Masterfile)
                .Where(c => c.SalesEvidenceId == salesEvidenceId)
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesEvidenceLACoordinate>> GetByMasterfileIdAsync(int masterfileId)
        {
            return await _context.SalesEvidenceLACoordinates
                .Include(c => c.SalesEvidence)
                .Include(c => c.Masterfile)
                .Where(c => c.MasterfileId == masterfileId)
                .ToListAsync();
        }

        public async Task<SalesEvidenceLACoordinate> CreateAsync(SalesEvidenceLACoordinate coordinate)
        {
            coordinate.CreatedAt = DateTime.UtcNow;
            _context.SalesEvidenceLACoordinates.Add(coordinate);
            await _context.SaveChangesAsync();
            
            await _context.Entry(coordinate)
                .Reference(c => c.SalesEvidence)
                .LoadAsync();
                
            return coordinate;
        }

        public async Task<bool> UpdateAsync(SalesEvidenceLACoordinate coordinate)
        {
            try
            {
                coordinate.UpdatedAt = DateTime.UtcNow;
                _context.Entry(coordinate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var coordinate = await _context.SalesEvidenceLACoordinates.FindAsync(id);
            if (coordinate == null)
            {
                return false;
            }

            _context.SalesEvidenceLACoordinates.Remove(coordinate);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.SalesEvidenceLACoordinates.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> SalesEvidenceExistsAsync(int salesEvidenceId)
        {
            return await _context.SalesEvidencesLA.AnyAsync(s => s.Id == salesEvidenceId);
        }

        public async Task<bool> MasterFileExistsAsync(int masterFileId)
        {
            return await _context.LandAquisitionMasterFiles.AnyAsync(m => m.Id == masterFileId);
        }
    }

    // RentalEvidenceLA Coordinate Repository
    public class RentalEvidenceLACoordinateRepository : IRentalEvidenceLACoordinateRepository
    {
        private readonly AppDbContext _context;

        public RentalEvidenceLACoordinateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RentalEvidenceLACoordinate>> GetAllAsync()
        {
            return await _context.RentalEvidenceLACoordinates
                .Include(c => c.RentalEvidence)
                .Include(c => c.Masterfile)
                .ToListAsync();
        }

        public async Task<RentalEvidenceLACoordinate> GetByIdAsync(int id)
        {
            return await _context.RentalEvidenceLACoordinates
                .Include(c => c.RentalEvidence)
                .Include(c => c.Masterfile)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<RentalEvidenceLACoordinate>> GetByRentalEvidenceIdAsync(int rentalEvidenceId)
        {
            return await _context.RentalEvidenceLACoordinates
                .Include(c => c.RentalEvidence)
                .Include(c => c.Masterfile)
                .Where(c => c.RentalEvidenceId == rentalEvidenceId)
                .ToListAsync();
        }

        public async Task<IEnumerable<RentalEvidenceLACoordinate>> GetByMasterfileIdAsync(int masterfileId)
        {
            return await _context.RentalEvidenceLACoordinates
                .Include(c => c.RentalEvidence)
                .Include(c => c.Masterfile)
                .Where(c => c.MasterfileId == masterfileId)
                .ToListAsync();
        }

        public async Task<RentalEvidenceLACoordinate> CreateAsync(RentalEvidenceLACoordinate coordinate)
        {
            coordinate.CreatedAt = DateTime.UtcNow;
            _context.RentalEvidenceLACoordinates.Add(coordinate);
            await _context.SaveChangesAsync();
            
            await _context.Entry(coordinate)
                .Reference(c => c.RentalEvidence)
                .LoadAsync();
                
            return coordinate;
        }

        public async Task<bool> UpdateAsync(RentalEvidenceLACoordinate coordinate)
        {
            try
            {
                coordinate.UpdatedAt = DateTime.UtcNow;
                _context.Entry(coordinate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var coordinate = await _context.RentalEvidenceLACoordinates.FindAsync(id);
            if (coordinate == null)
            {
                return false;
            }

            _context.RentalEvidenceLACoordinates.Remove(coordinate);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.RentalEvidenceLACoordinates.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> RentalEvidenceExistsAsync(int rentalEvidenceId)
        {
            return await _context.RentalEvidencesLA.AnyAsync(r => r.Id == rentalEvidenceId);
        }

        public async Task<bool> MasterFileExistsAsync(int masterFileId)
        {
            return await _context.LandAquisitionMasterFiles.AnyAsync(m => m.Id == masterFileId);
        }
    }
}
