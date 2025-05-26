public class LandAquisitionMasterFile
{
    public int Id { get; set; }
    public int MasterFileNo { get; set; }
    public string MasterFilesRefNo { get; set; } = string.Empty;
    public string PlanType { get; set; } = string.Empty;
    public string PlanNo { get; set; } = string.Empty;
    public string RequestingAuthorityReferenceNo { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}

public class LAQueryRequest
{
    public string Query { get; set; } = string.Empty;
}
