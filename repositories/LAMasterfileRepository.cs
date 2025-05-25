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

        public List<LandAquisitionMasterFile> Search(string query)
        {
            query = query.ToLower();
            return _context.LandAquisitionMasterFiles
                .Where(f =>
                    f.MasterFileNo.ToString().Contains(query) ||
                    f.MasterFilesRefNo.ToLower().Contains(query) ||
                    f.PlanNo.ToLower().Contains(query) ||
                    f.PlanType.ToLower().Contains(query) ||
                    f.RequestingAuthorityReferenceNo.ToLower().Contains(query) ||
                    f.Status.ToLower().Contains(query))
                .ToList();
        }
    }
}
