using System.ComponentModel.DataAnnotations;

namespace ValuationBackend.Models
{
    public class RatingRequest
    {
        public int Id { get; set; }  // Auto-increment ID

        public string RequestType { get; set; } // mass rating, rating assessment, etc.
        public string RatingReferenceNo { get; set; }
        public string LocalAuthority { get; set; }
        public int YearOfRevision { get; set; }
        public string Status { get; set; }
    }
}