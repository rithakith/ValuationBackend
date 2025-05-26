using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{    public interface IRequestRepository
    {
        List<Request> GetAll();
        List<Request> GetByRequestTypeId(int requestTypeId);
        List<Request> GetByStatus(bool status, int requestTypeId);
        List<Request> GetByYearOfRevision(int year, int requestTypeId);
        List<Request> GetByRatingReferenceNo(string ratingReferenceNo, int requestTypeId);
    }
}
