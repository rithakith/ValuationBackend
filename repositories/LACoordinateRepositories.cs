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
                .Include(c => c.Report)
                .ToListAsync();
        }

        public async Task<PastValuationsLACoordinate> GetByIdAsync(int id)
        {
            return await _context.PastValuationsLACoordinates
                .Include(c => c.Report)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<PastValuationsLACoordinate>> GetByReportIdAsync(int reportId)
        {
            return await _context.PastValuationsLACoordinates
                .Include(c => c.Report)
                .Where(c => c.ReportId == reportId)
                .ToListAsync();
        }

        public async Task<PastValuationsLACoordinate> CreateAsync(PastValuationsLACoordinate coordinate)
        {
            coordinate.CreatedAt = DateTime.UtcNow;
            _context.PastValuationsLACoordinates.Add(coordinate);
            await _context.SaveChangesAsync();
            
            await _context.Entry(coordinate)
                .Reference(c => c.Report)
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

        public async Task<bool> ReportExistsAsync(int reportId)
        {
            return await _context.Reports.AnyAsync(r => r.ReportId == reportId);
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
                .Include(c => c.Report)
                .ToListAsync();
        }

        public async Task<BuildingRatesLACoordinate> GetByIdAsync(int id)
        {
            return await _context.BuildingRatesLACoordinates
                .Include(c => c.Report)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<BuildingRatesLACoordinate>> GetByReportIdAsync(int reportId)
        {
            return await _context.BuildingRatesLACoordinates
                .Include(c => c.Report)
                .Where(c => c.ReportId == reportId)
                .ToListAsync();
        }

        public async Task<BuildingRatesLACoordinate> CreateAsync(BuildingRatesLACoordinate coordinate)
        {
            coordinate.CreatedAt = DateTime.UtcNow;
            _context.BuildingRatesLACoordinates.Add(coordinate);
            await _context.SaveChangesAsync();
            
            await _context.Entry(coordinate)
                .Reference(c => c.Report)
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

        public async Task<bool> ReportExistsAsync(int reportId)
        {
            return await _context.Reports.AnyAsync(r => r.ReportId == reportId);
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
                .Include(c => c.Report)
                .ToListAsync();
        }

        public async Task<SalesEvidenceLACoordinate> GetByIdAsync(int id)
        {
            return await _context.SalesEvidenceLACoordinates
                .Include(c => c.Report)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<SalesEvidenceLACoordinate>> GetByReportIdAsync(int reportId)
        {
            return await _context.SalesEvidenceLACoordinates
                .Include(c => c.Report)
                .Where(c => c.ReportId == reportId)
                .ToListAsync();
        }

        public async Task<SalesEvidenceLACoordinate> CreateAsync(SalesEvidenceLACoordinate coordinate)
        {
            coordinate.CreatedAt = DateTime.UtcNow;
            _context.SalesEvidenceLACoordinates.Add(coordinate);
            await _context.SaveChangesAsync();
            
            await _context.Entry(coordinate)
                .Reference(c => c.Report)
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

        public async Task<bool> ReportExistsAsync(int reportId)
        {
            return await _context.Reports.AnyAsync(r => r.ReportId == reportId);
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
                .Include(c => c.Report)
                .ToListAsync();
        }

        public async Task<RentalEvidenceLACoordinate> GetByIdAsync(int id)
        {
            return await _context.RentalEvidenceLACoordinates
                .Include(c => c.Report)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<RentalEvidenceLACoordinate>> GetByReportIdAsync(int reportId)
        {
            return await _context.RentalEvidenceLACoordinates
                .Include(c => c.Report)
                .Where(c => c.ReportId == reportId)
                .ToListAsync();
        }

        public async Task<RentalEvidenceLACoordinate> CreateAsync(RentalEvidenceLACoordinate coordinate)
        {
            coordinate.CreatedAt = DateTime.UtcNow;
            _context.RentalEvidenceLACoordinates.Add(coordinate);
            await _context.SaveChangesAsync();
            
            await _context.Entry(coordinate)
                .Reference(c => c.Report)
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

        public async Task<bool> ReportExistsAsync(int reportId)
        {
            return await _context.Reports.AnyAsync(r => r.ReportId == reportId);
        }
    }
}
