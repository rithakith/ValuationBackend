using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface ILAMasterfileRepository
    {
        List<LandAquisitionMasterFile> GetAll();
        List<LandAquisitionMasterFile> Search(string query);
    }
}
