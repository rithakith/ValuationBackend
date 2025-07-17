using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class AssignMissingLMTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // First, get usernames for the round-robin assignment
            // User 1 = Jalina, User 2 = Akith, User 3 = Dulmini, User 4 = Vishwa, User 5 = Rithara
            
            // Insert UserTask records for LM tasks 8-18, assigning to users 1-5 in round-robin fashion
            // Tasks 8, 13, 18 → User 1 (Jalina)
            migrationBuilder.Sql(@"
                INSERT INTO ""UserTasks"" (""Username"", ""UserId"", ""TaskType"", ""LandMiscellaneousId"", ""IsCompleted"", ""AssignedDate"") 
                SELECT u.""Username"", u.""Id"", 'LM', 8, false, CURRENT_TIMESTAMP
                FROM ""Users"" u WHERE u.""Id"" = 1;
            ");
            
            migrationBuilder.Sql(@"
                INSERT INTO ""UserTasks"" (""Username"", ""UserId"", ""TaskType"", ""LandMiscellaneousId"", ""IsCompleted"", ""AssignedDate"") 
                SELECT u.""Username"", u.""Id"", 'LM', 13, false, CURRENT_TIMESTAMP
                FROM ""Users"" u WHERE u.""Id"" = 1;
            ");
            
            migrationBuilder.Sql(@"
                INSERT INTO ""UserTasks"" (""Username"", ""UserId"", ""TaskType"", ""LandMiscellaneousId"", ""IsCompleted"", ""AssignedDate"") 
                SELECT u.""Username"", u.""Id"", 'LM', 18, false, CURRENT_TIMESTAMP
                FROM ""Users"" u WHERE u.""Id"" = 1;
            ");

            // Tasks 9, 14 → User 2 (Akith)
            migrationBuilder.Sql(@"
                INSERT INTO ""UserTasks"" (""Username"", ""UserId"", ""TaskType"", ""LandMiscellaneousId"", ""IsCompleted"", ""AssignedDate"") 
                SELECT u.""Username"", u.""Id"", 'LM', 9, false, CURRENT_TIMESTAMP
                FROM ""Users"" u WHERE u.""Id"" = 2;
            ");
            
            migrationBuilder.Sql(@"
                INSERT INTO ""UserTasks"" (""Username"", ""UserId"", ""TaskType"", ""LandMiscellaneousId"", ""IsCompleted"", ""AssignedDate"") 
                SELECT u.""Username"", u.""Id"", 'LM', 14, false, CURRENT_TIMESTAMP
                FROM ""Users"" u WHERE u.""Id"" = 2;
            ");

            // Tasks 10, 15 → User 3 (Dulmini)
            migrationBuilder.Sql(@"
                INSERT INTO ""UserTasks"" (""Username"", ""UserId"", ""TaskType"", ""LandMiscellaneousId"", ""IsCompleted"", ""AssignedDate"") 
                SELECT u.""Username"", u.""Id"", 'LM', 10, false, CURRENT_TIMESTAMP
                FROM ""Users"" u WHERE u.""Id"" = 3;
            ");
            
            migrationBuilder.Sql(@"
                INSERT INTO ""UserTasks"" (""Username"", ""UserId"", ""TaskType"", ""LandMiscellaneousId"", ""IsCompleted"", ""AssignedDate"") 
                SELECT u.""Username"", u.""Id"", 'LM', 15, false, CURRENT_TIMESTAMP
                FROM ""Users"" u WHERE u.""Id"" = 3;
            ");

            // Tasks 11, 16 → User 4 (Vishwa)
            migrationBuilder.Sql(@"
                INSERT INTO ""UserTasks"" (""Username"", ""UserId"", ""TaskType"", ""LandMiscellaneousId"", ""IsCompleted"", ""AssignedDate"") 
                SELECT u.""Username"", u.""Id"", 'LM', 11, false, CURRENT_TIMESTAMP
                FROM ""Users"" u WHERE u.""Id"" = 4;
            ");
            
            migrationBuilder.Sql(@"
                INSERT INTO ""UserTasks"" (""Username"", ""UserId"", ""TaskType"", ""LandMiscellaneousId"", ""IsCompleted"", ""AssignedDate"") 
                SELECT u.""Username"", u.""Id"", 'LM', 16, false, CURRENT_TIMESTAMP
                FROM ""Users"" u WHERE u.""Id"" = 4;
            ");

            // Tasks 12, 17 → User 5 (Rithara)
            migrationBuilder.Sql(@"
                INSERT INTO ""UserTasks"" (""Username"", ""UserId"", ""TaskType"", ""LandMiscellaneousId"", ""IsCompleted"", ""AssignedDate"") 
                SELECT u.""Username"", u.""Id"", 'LM', 12, false, CURRENT_TIMESTAMP
                FROM ""Users"" u WHERE u.""Id"" = 5;
            ");
            
            migrationBuilder.Sql(@"
                INSERT INTO ""UserTasks"" (""Username"", ""UserId"", ""TaskType"", ""LandMiscellaneousId"", ""IsCompleted"", ""AssignedDate"") 
                SELECT u.""Username"", u.""Id"", 'LM', 17, false, CURRENT_TIMESTAMP
                FROM ""Users"" u WHERE u.""Id"" = 5;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the UserTask assignments for LM tasks 8-18
            migrationBuilder.Sql(@"
                DELETE FROM ""UserTasks"" 
                WHERE ""TaskType"" = 'LM' 
                AND ""LandMiscellaneousId"" IN (8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18);
            ");
        }
    }
}
