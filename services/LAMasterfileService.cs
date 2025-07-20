using System;
using ValuationBackend.Models;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class LAMasterfileService : ILAMasterfileService
    {
        private readonly ILAMasterfileRepository _repository;

        public LAMasterfileService(ILAMasterfileRepository repository)
        {
            _repository = repository;
        }

        public LAMasterfileResponse GetAll(string sortBy = "")
        {
            var data = _repository.GetAll(sortBy);
            return new LAMasterfileResponse { MasterFiles = data };
        }

        public LAMasterfileResponse GetPaged(int page, int pageSize, string sortBy = "")
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            var (items, totalCount) = _repository.GetPaged(page, pageSize, sortBy);
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            return new LAMasterfileResponse
            {
                MasterFiles = items,
                TotalCount = totalCount,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                SortBy = sortBy
            };
        }

        public LAMasterfileResponse Search(string query, string sortBy = "")
        {
            var data = _repository.Search(query, sortBy);
            return new LAMasterfileResponse { MasterFiles = data };
        }

        public LAMasterfileResponse SearchPaged(string query, int page, int pageSize, string sortBy = "")
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            var (items, totalCount) = _repository.SearchPaged(query, page, pageSize, sortBy);
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            return new LAMasterfileResponse
            {
                MasterFiles = items,
                TotalCount = totalCount,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                SearchTerm = query,
                SortBy = sortBy
            };
        }
    }
}
