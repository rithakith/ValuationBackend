using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface IPropertyCategoryRepository
    {
        List<PropertyCategory> GetAll();
    }
}
