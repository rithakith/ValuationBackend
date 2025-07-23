using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Services;
using ValuationBackend.Data;
using ValuationBackend.Models;      
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/decision-fields")]
public class DecisionFieldController : ControllerBase
{
    private readonly ValuationContext _context;

    public DecisionFieldController(ValuationContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateField([FromBody] DecisionField field)
    {
        _context.DecisionFields.Add(field);
        await _context.SaveChangesAsync();
        return Ok(field);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFields()
    {
        var fields = await _context.DecisionFields.ToListAsync();
        return Ok(fields);
    }
}
