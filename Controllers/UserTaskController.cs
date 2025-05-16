using Microsoft.AspNetCore.Mvc;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTaskController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserTaskController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("overview")]
        public ActionResult<UserTaskOverviewResponse> GetTaskOverview([FromBody] UserTaskOverviewRequest request)
        {
            var userTasks = _context.UserTasks.Where(t => t.Username == request.Username).ToList();

            var laAssigned = userTasks.Count(t => t.TaskType == "LA");
            var laCompleted = userTasks.Count(t => t.TaskType == "LA" && t.IsCompleted);
            var mrAssigned = userTasks.Count(t => t.TaskType == "MR");
            var mrCompleted = userTasks.Count(t => t.TaskType == "MR" && t.IsCompleted);
            var lmAssigned = userTasks.Count(t => t.TaskType == "LM");
            var lmCompleted = userTasks.Count(t => t.TaskType == "LM" && t.IsCompleted);

            return Ok(new UserTaskOverviewResponse
            {
                LaTaskAssigned = laAssigned,
                LaTaskCompleted = laCompleted,
                MrTaskAssigned = mrAssigned,
                MrTaskCompleted = mrCompleted,
                LmTaskAssigned = lmAssigned,
                LandMiscelleneous = lmCompleted + (lmAssigned - lmCompleted),
                TotalTasksAssigned = userTasks.Count,
                TotalTasksCompleted = userTasks.Count(t => t.IsCompleted)
            });
        }

        [HttpPost("work-summary")]
        public ActionResult<UserWorkSummaryResponse> GetWorkSummary([FromBody] UserTaskOverviewRequest request)
        {
            var userTasks = _context.UserTasks
                .Where(t => t.Username == request.Username && t.IsCompleted)
                .AsEnumerable()
                .GroupBy(t => t.AssignedDate.ToString("yyyyMM"))
                .ToDictionary(g => g.Key, g => g.Count());

            return Ok(new UserWorkSummaryResponse(userTasks));
        }
    }
}