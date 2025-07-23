using System;
using System.Collections.Generic;

namespace ValuationBackend;

public partial class PastValuationsLa
{
    public int Id { get; set; }

    public int ReportId { get; set; }

    public string MasterFileRefNo { get; set; } = null!;

    public string? FileNoGndivision { get; set; }

    public string? Situation { get; set; }

    public string? DateOfValuation { get; set; }

    public string? PurposeOfValuation { get; set; }

    public string? PlanOfParticulars { get; set; }

    public string? Extent { get; set; }

    public string? Rate { get; set; }

    public string? RateType { get; set; }

    public string? Remarks { get; set; }

    public string? LocationLongitude { get; set; }

    public string? LocationLatitude { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int MasterFileId { get; set; }
}
