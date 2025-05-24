using System;

namespace ValuationBackend.Models.DTOs
{
    // Response DTO for successful past valuations LA creation
    public class PastValuationsLACreationResponseDto
    {
        public string Msg { get; set; }
        public int ReportId { get; set; }
    }
}
