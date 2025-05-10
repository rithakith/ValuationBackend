namespace ValuationBackend.Models
{
    public class ImageData
    {
        public int Id { get; set; }
        public string ReportId { get; set; } = string.Empty;
        public string ImageBase64 { get; set; } = string.Empty;
    }

    public class SendImageDataRequest
    {
        public string ReportId { get; set; } = string.Empty;
        public List<string> Images { get; set; } = new();
    }
}
