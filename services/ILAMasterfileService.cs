using ValuationBackend.Models;

namespace ValuationBackend.Services
{
    public interface ILAMasterfileService
    {
        LAMasterfileResponse GetAll(string sortBy = "");
        LAMasterfileResponse GetPaged(int page, int pageSize, string sortBy = "");
        LAMasterfileResponse Search(string query, string sortBy = "");
        LAMasterfileResponse SearchPaged(string query, int page, int pageSize, string sortBy = "");
    }
}
