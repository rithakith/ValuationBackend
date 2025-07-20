using System.Collections.Generic;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface ILAMasterfileRepository
    {
        List<LandAquisitionMasterFile> GetAll(string sortBy = "", int? assignedToUserId = null);
        (List<LandAquisitionMasterFile> Items, int TotalCount) GetPaged(int page, int pageSize, string sortBy = "", int? assignedToUserId = null);
        List<LandAquisitionMasterFile> Search(string query, string sortBy = "", int? assignedToUserId = null);
        (List<LandAquisitionMasterFile> Items, int TotalCount) SearchPaged(string query, int page, int pageSize, string sortBy = "", int? assignedToUserId = null);
    }
}
