namespace ValuationBackend.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string TaskType { get; set; } = string.Empty; // LA, MR, LM
        public bool IsCompleted { get; set; }
        public DateTime AssignedDate { get; set; }
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