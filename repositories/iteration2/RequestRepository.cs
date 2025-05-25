using Microsoft.EntityFrameworkCore;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppDbContext _context;

        public RequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Request> GetAll()
        {
            return _context.Requests.Include(r => r.RequestType).OrderBy(r => r.CreatedAt).ToList();
        }

        public List<Request> GetByRequestTypeId(int requestTypeId)
        {
            return _context
                .Requests.Include(r => r.RequestType)
                .Where(r => r.RequestTypeId == requestTypeId)
                .OrderBy(r => r.RatingReferenceNo) // Sort by ascending order of rating reference no
                .ToList();
        }

        public List<Request> GetByStatus(bool status, int requestTypeId)
        {
            return _context
                .Requests.Include(r => r.RequestType)
                .Where(r => r.Status == status && r.RequestTypeId == requestTypeId)
                .OrderBy(r => r.RequestTypeId)
                .ThenBy(r => r.CreatedAt)
                .ToList();
        }

        public List<Request> GetByYearOfRevision(int year, int requestTypeId)
        {
            return _context
                .Requests.Include(r => r.RequestType)
                .Where(r => r.YearOfRevision == year && r.RequestTypeId == requestTypeId)
                .OrderBy(r => r.RequestTypeId)
                .ThenBy(r => r.CreatedAt)
                .ToList();
        }

        public List<Request> GetByRatingReferenceNo(string ratingReferenceNo, int requestTypeId)
        {
            return _context
                .Requests.Include(r => r.RequestType)
                .Where(r => r.RatingReferenceNo.Contains(ratingReferenceNo) && r.RequestTypeId == requestTypeId)
                .OrderBy(r => r.RequestTypeId)
                .ThenBy(r => r.RatingReferenceNo)
                .ToList();
        }
    }
}
