using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public class DecisionFieldRepository
    {
        private readonly ValuationContext _context;

        public DecisionFieldRepository(ValuationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DecisionField>> GetAllAsync()
        {
            return await _context.DecisionFields.ToListAsync();
        }

        public async Task<DecisionField> AddAsync(DecisionField field)
        {
            _context.DecisionFields.Add(field);
            await _context.SaveChangesAsync();
            return field;
        }

        // Add more methods as needed (e.g., GetByIdAsync, UpdateAsync, DeleteAsync)
    }
}
