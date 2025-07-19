using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class ImageData
    {
        public int Id { get; set; }
        public string ReportId { get; set; } = string.Empty;
        public string ImageBase64 { get; set; } = string.Empty;
        [Column("parent_id")]
        public string? ParentId { get; set; } // Nullable for backward compatibility
        [Column("parent_type")]
        public string? ParentType { get; set; }
    }

    public class SendImageDataRequest
    {
        public string ReportId { get; set; } = string.Empty;
        public List<string> Images { get; set; } = new();
    }
}
