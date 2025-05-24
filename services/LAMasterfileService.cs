using ValuationBackend.Models;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class LAMasterfileService : ILAMasterfileService
    {
        private readonly ILAMasterfileRepository _repository;

        public LAMasterfileService(ILAMasterfileRepository repository)
        {
            _repository = repository;
        }

        public LAMasterfileResponse GetAll()
        {
            var data = _repository.GetAll();
            return new LAMasterfileResponse { MasterFiles = data };
        }

        public LAMasterfileResponse Search(string query)
        {
            var data = _repository.Search(query);
            return new LAMasterfileResponse { MasterFiles = data };
        }
    }
}
