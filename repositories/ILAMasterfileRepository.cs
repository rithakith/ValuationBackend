using System.Collections.Generic;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface ILAMasterfileRepository
    {
        List<LandAquisitionMasterFile> GetAll();
        (List<LandAquisitionMasterFile> Items, int TotalCount) GetPaged(int page, int pageSize);
        List<LandAquisitionMasterFile> Search(string query);
        (List<LandAquisitionMasterFile> Items, int TotalCount) SearchPaged(string query, int page, int pageSize);
    }
}
