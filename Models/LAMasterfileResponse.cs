using System.Collections.Generic;

namespace ValuationBackend.Models
{
    public class LAMasterfileResponse
    {
        public IEnumerable<LandAquisitionMasterFile> MasterFiles { get; set; } = new List<LandAquisitionMasterFile>();
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public string? SortBy { get; set; }
        public string? SearchTerm { get; set; }
    }
} 