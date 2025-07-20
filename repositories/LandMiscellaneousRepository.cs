using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class LandMiscellaneousRepository : ILandMiscellaneousRepository
    {
        private readonly AppDbContext _context;

        public LandMiscellaneousRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LandMiscellaneousMasterFile>> GetAllAsync(string sortBy = "", int? assignedToUserId = null)
        {
            var query = _context.LandMiscellaneousMasterFiles.AsQueryable();

            // Apply user filtering if assignedToUserId is provided
            query = ApplyUserFiltering(query, assignedToUserId);

            // Apply sorting
            query = ApplySorting(query, sortBy);

            return await query.ToListAsync();
        }

        public async Task<List<LandMiscellaneousMasterFile>> GetPaginatedAsync(int pageNumber, int pageSize, string sortBy = "", int? assignedToUserId = null)
        {
            var query = _context.LandMiscellaneousMasterFiles.AsQueryable();

            // Apply user filtering if assignedToUserId is provided
            query = ApplyUserFiltering(query, assignedToUserId);

            // Apply sorting
            query = ApplySorting(query, sortBy);

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalCountAsync(int? assignedToUserId = null)
        {
            var query = _context.LandMiscellaneousMasterFiles.AsQueryable();

            // Apply user filtering if assignedToUserId is provided
            query = ApplyUserFiltering(query, assignedToUserId);

            return await query.CountAsync();
        }

        public async Task<List<LandMiscellaneousMasterFile>> SearchAsync(string searchTerm, int pageNumber, int pageSize, string sortBy = "", int? assignedToUserId = null)
        {
            var query = _context.LandMiscellaneousMasterFiles.AsQueryable();

            // Apply user filtering if assignedToUserId is provided
            query = ApplyUserFiltering(query, assignedToUserId);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                // Convert searchTerm to lowercase for case-insensitive search
                var lowerSearchTerm = searchTerm.ToLower();

                // Check if searchTerm is numeric for MasterFileNo search
                bool isNumeric = int.TryParse(searchTerm, out int masterFileNo);

                query = query.Where(l =>
                    (isNumeric && l.MasterFileNo == masterFileNo) ||
                    (l.PlanType != null && l.PlanType.ToLower().Contains(lowerSearchTerm)) ||
                    (l.PlanNo != null && l.PlanNo.ToLower().Contains(lowerSearchTerm)) ||
                    (l.RequestingAuthorityReferenceNo != null && l.RequestingAuthorityReferenceNo.ToLower().Contains(lowerSearchTerm)) ||
                    (l.Status != null && l.Status.ToLower().Contains(lowerSearchTerm)) ||
                    l.MasterFileNo.ToString().Contains(searchTerm)
                );
            }

            // Apply sorting
            query = ApplySorting(query, sortBy);

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        private IQueryable<LandMiscellaneousMasterFile> ApplyUserFiltering(IQueryable<LandMiscellaneousMasterFile> query, int? assignedToUserId)
        {
            if (!assignedToUserId.HasValue)
            {
                return query; // No filtering if no user specified
            }

            // Join with UserTasks to filter by assigned user ID for LM tasks
            // Use the more efficient UserId-based filtering
            return query.Where(lm => _context.UserTasks
                .Any(ut => ut.UserId == assignedToUserId.Value &&
                          ut.TaskType == "LM" &&
                          ut.LandMiscellaneousId == lm.Id));
        }

        private IQueryable<LandMiscellaneousMasterFile> ApplySorting(IQueryable<LandMiscellaneousMasterFile> query, string sortBy)
        {
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                return query.OrderBy(x => x.Id); // Default sorting
            }

            return sortBy.ToLower() switch
            {
                "id" => query.OrderBy(x => x.Id),
                "masterfileno" => query.OrderBy(x => x.MasterFileNo),
                "plantype" => query.OrderBy(x => x.PlanType),
                "planno" => query.OrderBy(x => x.PlanNo),
                "requestingauthorityreferenceno" => query.OrderBy(x => x.RequestingAuthorityReferenceNo),
                "status" => query.OrderBy(x => x.Status),
                _ => query.OrderBy(x => x.Id) // Default fallback
            };
        }

        public async Task<int> GetSearchCountAsync(string searchTerm, int? assignedToUserId = null)
        {
            var query = _context.LandMiscellaneousMasterFiles.AsQueryable();

            // Apply user filtering if assignedToUserId is provided
            query = ApplyUserFiltering(query, assignedToUserId);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                // Convert searchTerm to lowercase for case-insensitive search
                var lowerSearchTerm = searchTerm.ToLower();

                // Check if searchTerm is numeric for MasterFileNo search
                bool isNumeric = int.TryParse(searchTerm, out int masterFileNo);

                query = query.Where(l =>
                    (isNumeric && l.MasterFileNo == masterFileNo) ||
                    (l.PlanType != null && l.PlanType.ToLower().Contains(lowerSearchTerm)) ||
                    (l.PlanNo != null && l.PlanNo.ToLower().Contains(lowerSearchTerm)) ||
                    (l.RequestingAuthorityReferenceNo != null && l.RequestingAuthorityReferenceNo.ToLower().Contains(lowerSearchTerm)) ||
                    (l.Status != null && l.Status.ToLower().Contains(lowerSearchTerm)) ||
                    l.MasterFileNo.ToString().Contains(searchTerm)
                );
            }

            return await query.CountAsync();
        }
    }
}
