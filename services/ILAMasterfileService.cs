using ValuationBackend.Models;

namespace ValuationBackend.Services
{
    public interface ILAMasterfileService
    {
        LAMasterfileResponse GetAll(string sortBy = "", int? assignedToUserId = null);
        LAMasterfileResponse GetPaged(int page, int pageSize, string sortBy = "", int? assignedToUserId = null);
        LAMasterfileResponse Search(string query, string sortBy = "", int? assignedToUserId = null);
        LAMasterfileResponse SearchPaged(string query, int page, int pageSize, string sortBy = "", int? assignedToUserId = null);
    }
}
