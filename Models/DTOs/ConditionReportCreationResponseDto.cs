using System;

namespace ValuationBackend.Models.DTOs
{
    // Response DTO for successful condition report creation
    public class ConditionReportCreationResponseDto
    {
        public string Msg { get; set; }
        public int ReportId { get; set; }
    }
}
