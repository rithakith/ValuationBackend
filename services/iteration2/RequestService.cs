using ValuationBackend.Models;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _repository;

        public RequestService(IRequestRepository repository)
        {
            _repository = repository;
        }

        public List<Request> GetAllRequests()
        {
            return _repository.GetAll();
        }

        public List<Request> GetRequestsByRequestTypeId(int requestTypeId)
        {
            return _repository.GetByRequestTypeId(requestTypeId);
        }

        public List<Request> GetRequestsByStatus(bool status, int requestTypeId)
        {
            return _repository.GetByStatus(status, requestTypeId);
        }

        public List<Request> GetRequestsByYearOfRevision(int year, int requestTypeId)
        {
            return _repository.GetByYearOfRevision(year, requestTypeId);
        }

        public List<Request> GetRequestsByRatingReferenceNo(
            string ratingReferenceNo,
            int requestTypeId
        )
        {
            return _repository.GetByRatingReferenceNo(ratingReferenceNo, requestTypeId);
        }
    }
}
