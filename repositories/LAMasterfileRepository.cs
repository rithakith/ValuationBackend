using Microsoft.EntityFrameworkCore;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class LAMasterfileRepository : ILAMasterfileRepository
    {
        private readonly AppDbContext _context;

        public LAMasterfileRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<LandAquisitionMasterFile> GetAll(string sortBy = "")
        {
            var query = _context.LandAquisitionMasterFiles.AsQueryable();
            query = ApplySorting(query, sortBy);
            return query.ToList();
        }

        public (List<LandAquisitionMasterFile> Items, int TotalCount) GetPaged(int page, int pageSize, string sortBy = "")
        {
            var query = _context.LandAquisitionMasterFiles.AsQueryable();
            
            // Apply sorting
            query = ApplySorting(query, sortBy);
            
            var totalCount = query.Count();
            var items = query.Skip((page - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
            return (items, totalCount);
        }

        public List<LandAquisitionMasterFile> Search(string query, string sortBy = "")
        {
            query = query.ToLower();
            var baseQuery = _context.LandAquisitionMasterFiles.Where(f =>
                f.MasterFileNo.ToString().Contains(query)
                || f.PlanNo.ToLower().Contains(query)
                || f.PlanType.ToLower().Contains(query)
                || f.RequestingAuthorityReferenceNo.ToLower().Contains(query)
                || f.Status.ToLower().Contains(query)
            );
            
            // Apply sorting
            baseQuery = ApplySorting(baseQuery, sortBy);
            
            return baseQuery.ToList();
        }

        public (List<LandAquisitionMasterFile> Items, int TotalCount) SearchPaged(string query, int page, int pageSize, string sortBy = "")
        {
            query = query.ToLower();
            var baseQuery = _context.LandAquisitionMasterFiles
                .Where(f =>
                    f.MasterFileNo.ToString().Contains(query) ||
                    f.MasterFilesRefNo.ToLower().Contains(query) ||
                    f.PlanNo.ToLower().Contains(query) ||
                    f.PlanType.ToLower().Contains(query) ||
                    f.RequestingAuthorityReferenceNo.ToLower().Contains(query) ||
                    f.Status.ToLower().Contains(query));

            // Apply sorting
            baseQuery = ApplySorting(baseQuery, sortBy);

            var totalCount = baseQuery.Count();
            var items = baseQuery.Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();
            return (items, totalCount);
        }

        private IQueryable<LandAquisitionMasterFile> ApplySorting(IQueryable<LandAquisitionMasterFile> query, string sortBy)
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
    }
}
