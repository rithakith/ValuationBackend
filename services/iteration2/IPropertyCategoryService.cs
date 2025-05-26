using ValuationBackend.Models;

namespace ValuationBackend.Services
{
    public interface IPropertyCategoryService
    {
        List<PropertyCategory> GetAllPropertyCategories();
    }
}
