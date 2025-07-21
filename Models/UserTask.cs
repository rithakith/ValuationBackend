using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    [Table("UserTasks")]
    public class UserTask
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public string TaskType { get; set; } = string.Empty; // LA, MR, LM
        public bool IsCompleted { get; set; }
        public DateTime AssignedDate { get; set; }

        // Reference fields to connect tasks to specific work items
        public int? RequestId { get; set; }           // For MR tasks (links to Request table)
        public int? LandAcquisitionId { get; set; }   // For LA tasks (links to LandAquisitionMasterFile)  
        public int? LandMiscellaneousId { get; set; }  // For LM tasks (links to LandMiscellaneousMasterFile)
        public string? WorkItemDescription { get; set; } // Human-readable task description
        public string? ReferenceNumber { get; set; }     // Easy reference (e.g., "MR-2024-001", "LM-2024-012")
    }

    public class UserTaskOverviewRequest
    {
        public string Username { get; set; } = string.Empty;
    }

    public class UserTaskOverviewResponse
    {
        public int LaTaskAssigned { get; set; }
        public int LaTaskCompleted { get; set; }
        public int MrTaskAssigned { get; set; }
        public int MrTaskCompleted { get; set; }
        public int LmTaskAssigned { get; set; }
        public int LandMiscelleneous { get; set; }
        public int TotalTasksAssigned { get; set; }
        public int TotalTasksCompleted { get; set; }
    }
}