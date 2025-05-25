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

        public async Task<LandMiscellaneousMasterFile?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<LandMiscellaneousMasterFile>> SearchByMasterFileNoAsync(int masterFileNo)
        {
            return await _repository.SearchByMasterFileNoAsync(masterFileNo);
        }
    }
}
