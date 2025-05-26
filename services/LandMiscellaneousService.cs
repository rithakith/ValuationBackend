using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class LandMiscellaneousService : ILandMiscellaneousService
    {
        private readonly ILandMiscellaneousRepository _repository;

        public LandMiscellaneousService(ILandMiscellaneousRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<LandMiscellaneousMasterFile>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<(List<LandMiscellaneousMasterFile> Records, int TotalCount)> GetPaginatedAsync(int pageNumber, int pageSize)
        {
            var records = await _repository.GetPaginatedAsync(pageNumber, pageSize);
            var totalCount = await _repository.GetTotalCountAsync();

            return (records, totalCount);
        }

        public async Task<(List<LandMiscellaneousMasterFile> Records, int TotalCount)> SearchAsync(string searchTerm, int pageNumber, int pageSize)
        {
            var records = await _repository.SearchAsync(searchTerm, pageNumber, pageSize);
            var totalCount = await _repository.GetSearchCountAsync(searchTerm);

            return (records, totalCount);
        }
    }
}
