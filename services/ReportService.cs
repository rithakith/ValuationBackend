using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;

        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Report>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Report?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Report> CreateAsync(Report report)
        {
            return await _repository.CreateAsync(report);
        }

        public async Task<Report> UpdateAsync(Report report)
        {
            return await _repository.UpdateAsync(report);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repository.ExistsAsync(id);
        }
    }
}
