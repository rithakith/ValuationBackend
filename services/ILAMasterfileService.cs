using ValuationBackend.Models;

namespace ValuationBackend.Services
{
    public interface ILAMasterfileService
    {
        LAMasterfileResponse GetAll();
        LAMasterfileResponse GetPaged(int page, int pageSize);
        LAMasterfileResponse Search(string query);
        LAMasterfileResponse SearchPaged(string query, int page, int pageSize);
    }
}
