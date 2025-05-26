using ValuationBackend.Models;

namespace ValuationBackend.Services
{    public interface IRequestService
    {
        List<Request> GetAllRequests();
        List<Request> GetRequestsByRequestTypeId(int requestTypeId);
        List<Request> GetRequestsByStatus(bool status, int requestTypeId);
        List<Request> GetRequestsByYearOfRevision(int year, int requestTypeId);
        List<Request> GetRequestsByRatingReferenceNo(string ratingReferenceNo, int requestTypeId);
    }
}
