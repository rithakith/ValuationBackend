using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConditionReportController : ControllerBase
    {
        private readonly IConditionReportService _conditionReportService;

        public ConditionReportController(IConditionReportService conditionReportService)
        {
            _conditionReportService = conditionReportService;
        }

        // GET: api/ConditionReport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConditionReportResponseDto>>> GetConditionReports()
        {
            return Ok(await _conditionReportService.GetAllAsync());
        }

        // GET: api/ConditionReport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConditionReportResponseDto>> GetConditionReport(int id)
        {
            var conditionReport = await _conditionReportService.GetByIdAsync(id);

            if (conditionReport == null)
            {
                return NotFound();
            }

            return conditionReport;
        }

        // POST: api/ConditionReport
        [HttpPost]
        public async Task<ActionResult<ConditionReportCreationResponseDto>> CreateConditionReport(ConditionReportCreateDto dto)
        {
            var result = await _conditionReportService.CreateAsync(dto);
            
            // Return the custom response format with msg and reportId
            var response = new ConditionReportCreationResponseDto
            {
                Msg = "success",
                ReportId = result.ReportId // Using the common report table ID, not the condition report ID
            };
            
            return Ok(response);
        }

        // PUT: api/ConditionReport/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConditionReport(int id, ConditionReportUpdateDto dto)
        {
            var result = await _conditionReportService.UpdateAsync(id, dto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/ConditionReport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConditionReport(int id)
        {
            var result = await _conditionReportService.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/ConditionReport/ByReport/{reportId}
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<ConditionReportResponseDto>> GetConditionReportByReportId(int reportId)
        {
            var conditionReport = await _conditionReportService.GetByReportIdAsync(reportId);

            if (conditionReport == null)
            {
                return NotFound();
            }

            return conditionReport;
        }
    }
}