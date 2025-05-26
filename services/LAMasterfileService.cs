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

        public LAMasterfileResponse GetAll()
        {
            var data = _repository.GetAll();
            return new LAMasterfileResponse { MasterFiles = data };
        }

        public LAMasterfileResponse GetPaged(int page, int pageSize)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            var (items, totalCount) = _repository.GetPaged(page, pageSize);
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            return new LAMasterfileResponse
            {
                MasterFiles = items,
                TotalCount = totalCount,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = totalPages
            };
        }

        public LAMasterfileResponse Search(string query)
        {
            var data = _repository.Search(query);
            return new LAMasterfileResponse { MasterFiles = data };
        }

        public LAMasterfileResponse SearchPaged(string query, int page, int pageSize)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            var (items, totalCount) = _repository.SearchPaged(query, page, pageSize);
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            return new LAMasterfileResponse
            {
                MasterFiles = items,
                TotalCount = totalCount,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = totalPages
            };
        }
    }
}
