using Microsoft.EntityFrameworkCore;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend
{
    public class AssignMissingTasks
    {
        public static async Task AssignTasksAsync(AppDbContext context)
        {
            // Get existing UserTask assignments for LM tasks
            var existingLMTasks = await context.UserTasks
                .Where(ut => ut.TaskType == "LM")
                .Select(ut => ut.LandMiscellaneousId)
                .ToListAsync();

            // Get all LandMiscellaneous IDs that exist
            var allLMIds = await context.LandMiscellaneousMasterFiles
                .Select(lm => lm.Id)
                .ToListAsync();

            // Find missing assignments (LM records without UserTask assignments)
            var missingLMIds = allLMIds.Except(existingLMTasks).ToList();

            if (missingLMIds.Any())
            {
                Console.WriteLine($"Found {missingLMIds.Count} unassigned Land Miscellaneous tasks: {string.Join(", ", missingLMIds)}");

                // Get users 1-5 for round-robin assignment
                var users = await context.Set<User>()
                    .Where(u => u.Id >= 1 && u.Id <= 5)
                    .OrderBy(u => u.Id)
                    .ToListAsync();

                if (users.Any())
                {
                    var newUserTasks = new List<UserTask>();

                    for (int i = 0; i < missingLMIds.Count; i++)
                    {
                        var assignedUser = users[i % users.Count]; // Round-robin assignment

                        var userTask = new UserTask
                        {
                            Username = assignedUser.Username,
                            UserId = assignedUser.Id,
                            TaskType = "LM",
                            LandMiscellaneousId = missingLMIds[i]
                        };

                        newUserTasks.Add(userTask);
                        Console.WriteLine($"Assigning LM task {missingLMIds[i]} to User {assignedUser.Id} ({assignedUser.Username})");
                    }

                    context.UserTasks.AddRange(newUserTasks);
                    await context.SaveChangesAsync();

                    Console.WriteLine($"Successfully assigned {newUserTasks.Count} tasks!");
                }
                else
                {
                    Console.WriteLine("No users found with IDs 1-5!");
                }
            }
            else
            {
                Console.WriteLine("All Land Miscellaneous tasks are already assigned!");
            }
        }
    }
}
