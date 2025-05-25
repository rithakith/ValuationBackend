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

        public List<LandAquisitionMasterFile> GetAll()
        {
            return _context.LandAquisitionMasterFiles.ToList();
        }

        public (List<LandAquisitionMasterFile> Items, int TotalCount) GetPaged(int page, int pageSize)
        {
            var query = _context.LandAquisitionMasterFiles;
            var totalCount = query.Count();
            var items = query.Skip((page - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
            return (items, totalCount);
        }

        public List<LandAquisitionMasterFile> Search(string query)
        {
            query = query.ToLower();
            return _context.LandAquisitionMasterFiles
                .Where(f =>
                    f.MasterFileNo.ToString().Contains(query) ||
                    f.PlanNo.ToLower().Contains(query) ||
                    f.PlanType.ToLower().Contains(query) ||
                    f.RequestingAuthorityReferenceNo.ToLower().Contains(query) ||
                    f.Status.ToLower().Contains(query))
                .ToList();
        }

        public (List<LandAquisitionMasterFile> Items, int TotalCount) SearchPaged(string query, int page, int pageSize)
        {
            query = query.ToLower();
            var baseQuery = _context.LandAquisitionMasterFiles
                .Where(f =>
                    f.MasterFileNo.ToString().Contains(query) ||
                    f.PlanNo.ToLower().Contains(query) ||
                    f.PlanType.ToLower().Contains(query) ||
                    f.RequestingAuthorityReferenceNo.ToLower().Contains(query) ||
                    f.Status.ToLower().Contains(query));

            var totalCount = baseQuery.Count();
            var items = baseQuery.Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();
            return (items, totalCount);
        }
    }
}
