using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class DecisionFieldService
    {
        private readonly DecisionFieldRepository _repository;

        public DecisionFieldService(DecisionFieldRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DecisionField>> GetAllFieldsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<DecisionField> CreateFieldAsync(DecisionField field)
        {
            return await _repository.AddAsync(field);
        }

        // Add more methods as needed for business logic
    }
}
