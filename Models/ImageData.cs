using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class ImageData
    {
        public int Id { get; set; }
        public int ReportId { get; set; } // Changed to int to match Reports.ReportId
        public string ImageBase64 { get; set; } = string.Empty;
    }

    public class SendImageDataRequest
    {
        public int ReportId { get; set; } // Changed to int
        public List<string> Images { get; set; } = new();
    }
}
