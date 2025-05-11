using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ValuationBackend.Models
{
    public class RatingRequest
    {
        public int Id { get; set; }
        public string RequestType { get; set; } // Mass Rating, etc.
        public string RatingReferenceNo { get; set; }
        public string LocalAuthority { get; set; }
        public int YearOfRevision { get; set; }
        public string Status { get; set; }






    }
}
