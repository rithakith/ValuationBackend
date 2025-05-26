using ValuationBackend.Models;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class RequestTypeService : IRequestTypeService
    {
        private readonly IRequestTypeRepository _repository;

        public RequestTypeService(IRequestTypeRepository repository)
        {
            _repository = repository;
        }

        public List<RequestType> GetAllRequestTypes()
        {
            return _repository.GetAll();
        }
    }
}
