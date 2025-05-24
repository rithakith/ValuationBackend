using ValuationBackend.Models;

namespace ValuationBackend.Services
{
    public interface ILAMasterfileService
    {
        LAMasterfileResponse GetAll();
        LAMasterfileResponse Search(string query);
    }
}
