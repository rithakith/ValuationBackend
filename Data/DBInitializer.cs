using System.Security.Cryptography;
using System.Text;
using ValuationBackend.Models;

namespace ValuationBackend.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Ensure DB is created
            context.Database.EnsureCreated();

            // Initialize Rating Requests
            InitializeRatingRequests(context);

            // Initialize Land Miscellaneous Master Files
            InitializeLandMiscellaneousMasterFiles(context);

            // Initialize Users
            InitializeUsers(context);

            // Initialize User Tasks
            InitializeUserTasks(context);

            // Initialize Master Data
            InitializeMasterData(context);

            // Initialize Land Aquisition Master Files  
            InitializeLandAquisitionMasterFiles(context);

        }

        private static void InitializeRatingRequests(AppDbContext context)
        {
            // If there's any data, stop
            if (context.RatingRequests.Any())
                return;

            // Add dummy records
            var requests = new RatingRequest[]
            {
                new RatingRequest
                {
                    RequestType = "Mass Rating",
                    RatingReferenceNo = "MR-001",
                    LocalAuthority = "Colombo MC",
                    YearOfRevision = 2022,
                    Status = "Pending"
                },
                new RatingRequest
                {
                    RequestType = "Rating Assessment",
                    RatingReferenceNo = "RA-001",
                    LocalAuthority = "Galle MC",
                    YearOfRevision = 2023,
                    Status = "Approved"
                },
                new RatingRequest
                {
                    RequestType = "Rating Building",
                    RatingReferenceNo = "RB-001",
                    LocalAuthority = "Kandy UC",
                    YearOfRevision = 2021,
                    Status = "Rejected"
                }
            };

            context.RatingRequests.AddRange(requests);
            context.SaveChanges();
        }


        private static void InitializeLandMiscellaneousMasterFiles(AppDbContext context)
        {
            // If there's any data, stop
            if (context.LandMiscellaneousMasterFiles.Any())
                return;

            // Add dummy records
            var masterFiles = new LandMiscellaneousMasterFile[]
            {
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52412,
                    PlanType = "Survey Plan",
                    PlanNo = "SP-2023-001",
                    RequestingAuthorityReferenceNo = "001",
                    Status = "Success",
                    Source = "https://example.com/plans/SP-2023-001"
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52413,
                    PlanType = "Block Survey",
                    PlanNo = "BS-2023-045",
                    RequestingAuthorityReferenceNo = "002",
                    Status = "Pending",
                    Source = "https://example.com/plans/BS-2023-045"
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52414,
                    PlanType = "Preliminary Plan",
                    PlanNo = "PP-2022-123",
                    RequestingAuthorityReferenceNo = "003",
                    Status = "Success",
                    Source = "https://example.com/plans/PP-2022-123"
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52415,
                    PlanType = "Final Village Plan",
                    PlanNo = "FVP-2021-078",
                    RequestingAuthorityReferenceNo = "004",
                    Status = "Rejected",
                    Source = "https://example.com/plans/FVP-2021-078"
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52416,
                    PlanType = "Topographical Survey",
                    PlanNo = "TS-2023-099",
                    RequestingAuthorityReferenceNo = "005",
                    Status = "Success",
                    Source = "https://example.com/plans/TS-2023-099"
                }
            };

            context.LandMiscellaneousMasterFiles.AddRange(masterFiles);
            context.SaveChanges();
        }

        private static void InitializeUsers(AppDbContext context)
{
    //if (context.Users.Any()) return;
    
    Console.WriteLine("Seeding users...");

    var users = new List<User>();

    void AddUser(string username, string password, string name, string email, string id, string position, string division)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512();
        users.Add(new User
        {
            Username = username,
            PasswordSalt = hmac.Key,
            PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)),
            EmpName = name,
            EmpEmail = email,
            EmpId = id,
            Position = position,
            AssignedDivision = division
        });
    }

    // Add dummy users
    AddUser("Jalina", "Jalina123", "Jalina Hirushan", "jalinahirushan@valdept.com", "1001V", "ADV", "Gampaha");
    AddUser("Akith", "Akith123", "Akith Chandinu", "akithchandinu@valdept.com", "1002V", "SUP", "Kurunegala");
    AddUser("Dulmini", "Dulmini123", "Samiksha Abeyweera", "samiksha@valdept.com", "1003V", "ADV", "Colombo");
    AddUser("Vishwa", "Vishwa123", "Vishwa Jayasankha", "vishwa@valdept.com", "1004V", "SUP", "Matara");
    AddUser("Rithara", "Rithara123", "Rithara Edirisinghe", "rithara@valdept.com", "1005V", "ADV", "Maradana");

    context.Users.AddRange(users);
    context.SaveChanges();
    Console.WriteLine("User data seeded.");
}

private static void InitializeUserTasks(AppDbContext context)
{
    if (context.UserTasks.Any()) return;

    Console.WriteLine("Seeding user tasks...");
    var tasks = new List<UserTask>();

    void AddTask(string username, string type, bool completed, string date)
    {
        tasks.Add(new UserTask
        {
            Username = username,
            TaskType = type,
            IsCompleted = completed,
            AssignedDate = DateTime.SpecifyKind(DateTime.ParseExact(date, "yyyyMMdd", null), DateTimeKind.Utc)
        });
    }

    AddTask("Jalina", "LA", true, "20250105");
    AddTask("Jalina", "MR", true, "20250115");
    AddTask("Jalina", "LM", false, "20250210");
    AddTask("Jalina", "LA", true, "20250301");

    AddTask("Akith", "MR", true, "20250120");
    AddTask("Akith", "LM", true, "20250212");
    AddTask("Akith", "LA", false, "20250225");
    AddTask("Akith", "LM", false, "20250303");

    AddTask("Dulmini", "LA", true, "20250110");
    AddTask("Dulmini", "MR", true, "20250112");
    AddTask("Dulmini", "MR", false, "20250302");
    AddTask("Dulmini", "LM", true, "20250310");

    AddTask("Vishwa", "LA", true, "20250101");
    AddTask("Vishwa", "LA", true, "20250215");
    AddTask("Vishwa", "LM", false, "20250305");
    AddTask("Vishwa", "MR", true, "20250318");

    AddTask("Rithara", "MR", true, "20250118");
    AddTask("Rithara", "LM", true, "20250222");
    AddTask("Rithara", "LA", false, "20250311");
    AddTask("Rithara", "LM", false, "20250330");

    context.UserTasks.AddRange(tasks);
    context.SaveChanges();
    Console.WriteLine("User tasks seeded.");
}

private static void InitializeMasterData(AppDbContext context)
{
    if (context.MasterDataItems.Any()) return;

    Console.WriteLine("Seeding master data...");

    var items = new List<(string Category, string Value)>
    {
        ("buildingCategory", "category1"), ("buildingCategory", "category2"),
        ("buildingClass", "classType1"), ("buildingClass", "classType2"),
        ("conviences", "type1"), ("conviences", "type2"),
        ("natureOfConstruction", "type1"), ("natureOfConstruction", "type2"),
        ("roofMaterial", "type1"), ("roofMaterial", "type2"),
        ("roofFrame", "type1"), ("roofFrame", "type2"),
        ("roofFinisher", "type1"), ("roofFinisher", "type2"),
        ("celing", "type1"), ("celing", "type2"),
        ("foundationStructure", "type1"), ("foundationStructure", "type2"),
        ("wallStructure", "type1"), ("wallStructure", "type2"),
        ("floorStructure", "type1"), ("floorStructure", "type2"),
        ("door", "type1"), ("door", "type2"),
        ("window", "type1"), ("window", "type2"),
        ("windowProtection", "type1"), ("windowProtection", "type2"),
        ("doorsBathroomAndToiletFittings", "type1"), ("doorsBathroomAndToiletFittings", "type2"),
        ("doorsHandRail", "type1"), ("doorsHandRail", "type2"),
        ("doorsPantryCupboard", "type1"), ("doorsPantryCupboard", "type2"),
        ("doorsOther", "type1"), ("doorsOther", "type2"),
        ("wallFinisher", "type1"), ("wallFinisher", "type2"),
        ("floorFinisher", "type1"), ("floorFinisher", "type2"),
        ("bathroomAndToilet", "type1"), ("bathroomAndToilet", "type2"),
        ("services", "type1"), ("services", "type2")
    };

    context.MasterDataItems.AddRange(
        items.Select(i => new MasterDataItem { Category = i.Category, Value = i.Value })
    );

    context.SaveChanges();
    Console.WriteLine("Master data seeded.");
}

private static void InitializeLandAquisitionMasterFiles(AppDbContext context)
{
    if (context.LandAquisitionMasterFiles.Any()) return;

    var files = new List<LandAquisitionMasterFile>
    {
        new() { MasterFileNo = 52412, PlanType = "Survey Plan", PlanNo = "SP-2023-001", RequestingAuthorityReferenceNo = "001", Status = "Success" },
        new() { MasterFileNo = 52413, PlanType = "Block Survey", PlanNo = "BS-2023-045", RequestingAuthorityReferenceNo = "002", Status = "Pending" }
    };

    context.LandAquisitionMasterFiles.AddRange(files);
    context.SaveChanges();
}



    }
}