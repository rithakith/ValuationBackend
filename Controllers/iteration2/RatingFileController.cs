using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/{requestType}/ratingfile")]
public class RatingFileController : ControllerBase
{
    // 1. Load all street names
    [HttpGet("streets")]
    public IActionResult GetStreets(string requestType)
    {
        var streets = new[]
        {
            new { id = "S1", name = "Main Street" },
            new { id = "S2", name = "Highway Road" },
            new { id = "S3", name = "Park Avenue" }
        };

        return Ok(new { streets });
    }

    // 2. Load obsolete numbers for selected street
    [HttpGet("streets/{streetId}/obsolete-numbers")]
    public IActionResult GetObsoleteNumbers(string requestType, string streetId)
    {
        var obsoleteNumbers = new[]
        {
            new { id = "O1", number = "101" },
            new { id = "O2", number = "102" },
            new { id = "O3", number = "103" }
        };

        return Ok(new { obsoleteNumbers });
    }
}
