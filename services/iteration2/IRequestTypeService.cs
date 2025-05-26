using ValuationBackend.Models;

namespace ValuationBackend.Services
{
    public interface IRequestTypeService
    {
        List<RequestType> GetAllRequestTypes();
    }
}
