using ValuationBackend.Models;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class PropertyCategoryService : IPropertyCategoryService
    {
        private readonly IPropertyCategoryRepository _repository;

        public PropertyCategoryService(IPropertyCategoryRepository repository)
        {
            _repository = repository;
        }

        public List<PropertyCategory> GetAllPropertyCategories()
        {
            return _repository.GetAll();
        }
    }
}
