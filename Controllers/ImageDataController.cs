using Microsoft.AspNetCore.Mvc;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageDataController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ImageDataController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ 1. Accept base64 images via JSON
        [HttpPost]
        public IActionResult SendImageData([FromBody] SendImageDataRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.ReportId) || request.Images == null || !request.Images.Any())
            {
                return BadRequest("Missing reportId or images.");
            }

            var imageEntities = request.Images.Select(img => new ImageData
            {
                ReportId = request.ReportId,
                ImageBase64 = img
            }).ToList();

            _context.ImageData.AddRange(imageEntities);
            _context.SaveChanges();

            return Ok(new { message = "Images saved successfully.", count = imageEntities.Count });
        }

        // ✅ 2. Accept actual image files via form-data
        [HttpPost("upload")]
        public async Task<IActionResult> UploadImages([FromForm] string reportId, [FromForm] List<IFormFile> files, [FromForm] string? parent_id, [FromForm] string? parent_type)
        {
            if (string.IsNullOrWhiteSpace(reportId) || files == null || !files.Any())
                return BadRequest("Missing reportId or files.");

            foreach (var file in files)
            {
                using var ms = new MemoryStream();
                await file.CopyToAsync(ms);
                var bytes = ms.ToArray();
                var base64 = Convert.ToBase64String(bytes);

                _context.ImageData.Add(new ImageData
                {
                    ReportId = reportId,
                    ImageBase64 = base64,
                    ParentId = parent_id,
                    ParentType = parent_type
                });
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Files uploaded and saved successfully.", count = files.Count });
        }
    }
}
