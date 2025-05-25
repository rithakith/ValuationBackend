using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface IRequestTypeRepository
    {
        List<RequestType> GetAll();
    }
}
