using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class PropertyCategoryRepository : IPropertyCategoryRepository
    {
        private readonly AppDbContext _context;

        public PropertyCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<PropertyCategory> GetAll()
        {
            return _context.PropertyCategories.ToList();
        }
    }
}
