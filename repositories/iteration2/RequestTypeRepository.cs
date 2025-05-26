using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class RequestTypeRepository : IRequestTypeRepository
    {
        private readonly AppDbContext _context;

        public RequestTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<RequestType> GetAll()
        {
            return _context.RequestTypes.ToList();
        }
    }
}
