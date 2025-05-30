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

        public async Task<List<LandMiscellaneousMasterFile>> GetAllAsync(string sortBy = "")
        {
            return await _repository.GetAllAsync(sortBy);
        }

        public async Task<(List<LandMiscellaneousMasterFile> Records, int TotalCount)> GetPaginatedAsync(int pageNumber, int pageSize, string sortBy = "")
        {
            var records = await _repository.GetPaginatedAsync(pageNumber, pageSize, sortBy);
            var totalCount = await _repository.GetTotalCountAsync();

            return (records, totalCount);
        }

        public async Task<(List<LandMiscellaneousMasterFile> Records, int TotalCount)> SearchAsync(string searchTerm, int pageNumber, int pageSize, string sortBy = "")
        {
            var records = await _repository.SearchAsync(searchTerm, pageNumber, pageSize, sortBy);
            var totalCount = await _repository.GetSearchCountAsync(searchTerm);

            return (records, totalCount);
        }
    }
}
