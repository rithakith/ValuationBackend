using Microsoft.EntityFrameworkCore;
using ValuationBackend.Data;
using ValuationBackend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Run the task assignment
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    try
    {
        Console.WriteLine("Checking for unassigned Land Miscellaneous tasks...");

        // Get existing UserTask assignments for LM tasks
        var existingLMTasks = await context.UserTasks
            .Where(ut => ut.TaskType == "LM")
            .Select(ut => ut.LandMiscellaneousId)
            .ToListAsync();

        Console.WriteLine($"Currently assigned LM task IDs: {string.Join(", ", existingLMTasks.OrderBy(x => x))}");

        // Get all LandMiscellaneous IDs that exist
        var allLMIds = await context.LandMiscellaneousMasterFiles
            .Select(lm => lm.Id)
            .OrderBy(lm => lm)
            .ToListAsync();

        Console.WriteLine($"All LM record IDs in database: {string.Join(", ", allLMIds)}");

        // Find missing assignments (LM records without UserTask assignments)
        var missingLMIds = allLMIds.Except(existingLMTasks).OrderBy(x => x).ToList();

        if (missingLMIds.Any())
        {
            Console.WriteLine($"Found {missingLMIds.Count} unassigned Land Miscellaneous tasks: {string.Join(", ", missingLMIds)}");

            // Get users 1-5 for round-robin assignment
            var users = await context.Set<User>()
                .Where(u => u.Id >= 1 && u.Id <= 5)
                .OrderBy(u => u.Id)
                .ToListAsync();

            Console.WriteLine($"Available users for assignment: {string.Join(", ", users.Select(u => $"{u.Id}({u.Username})"))}");

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

                Console.WriteLine($"✅ Successfully assigned {newUserTasks.Count} tasks!");

                // Show final assignment summary
                var finalAssignments = await context.UserTasks
                    .Where(ut => ut.TaskType == "LM")
                    .Include(ut => ut.User)
                    .OrderBy(ut => ut.LandMiscellaneousId)
                    .ToListAsync();

                Console.WriteLine("\n📋 Final LM Task Assignments:");
                foreach (var assignment in finalAssignments)
                {
                    Console.WriteLine($"  LM-{assignment.LandMiscellaneousId} → User {assignment.UserId} ({assignment.Username})");
                }
            }
            else
            {
                Console.WriteLine("❌ No users found with IDs 1-5!");
            }
        }
        else
        {
            Console.WriteLine("✅ All Land Miscellaneous tasks are already assigned!");

            // Show current assignments
            var currentAssignments = await context.UserTasks
                .Where(ut => ut.TaskType == "LM")
                .Include(ut => ut.User)
                .OrderBy(ut => ut.LandMiscellaneousId)
                .ToListAsync();

            Console.WriteLine("\n📋 Current LM Task Assignments:");
            foreach (var assignment in currentAssignments)
            {
                Console.WriteLine($"  LM-{assignment.LandMiscellaneousId} → User {assignment.UserId} ({assignment.Username})");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error: {ex.Message}");
        Console.WriteLine($"Stack trace: {ex.StackTrace}");
    }
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
