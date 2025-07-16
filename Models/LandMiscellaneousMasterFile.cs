using System;

namespace ValuationBackend.Models
{
    public class LandMiscellaneousMasterFile
    {
        public int Id { get; set; }
        public int MasterFileNo { get; set; }
        public string? PlanType { get; set; }
        public string? PlanNo { get; set; }
        public string? RequestingAuthorityReferenceNo { get; set; }
        public string? Status { get; set; }
        public int Lots { get; set; }
    }
}