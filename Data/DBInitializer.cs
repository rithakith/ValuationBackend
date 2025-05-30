using System.Security.Cryptography;
using System.Text;
using ValuationBackend.Models;

namespace ValuationBackend.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            try
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
                InitializeMasterData(context); // Initialize Land Aquisition Master Files
                InitializeLandAquisitionMasterFiles(context);

                // Initialize Reports
                InitializeReports(context);

                // Initialize Request Types
                InitializeRequestTypes(context);

                // Initialize Requests
                InitializeRequests(context); 
                  // Initialize Assets
                InitializeAssets(context);

                // Initialize Property Categories
                InitializePropertyCategories(context);
                
                // Initialize Asset Divisions
                InitializeAssetDivisions(context);
                
                // Initialize Reconciliations
                InitializeReconciliations(context);
                
                // Initialize Domestic Rating Cards
                DomesticRatingCardInitializer.InitializeDomesticRatingCards(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database initialization error: {ex.Message}");
                throw; // Re-throw to let the caller handle it
            }
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
                    Status = "Pending",
                },
                new RatingRequest
                {
                    RequestType = "Rating Assessment",
                    RatingReferenceNo = "RA-001",
                    LocalAuthority = "Galle MC",
                    YearOfRevision = 2023,
                    Status = "Approved",
                },
                new RatingRequest
                {
                    RequestType = "Rating Building",
                    RatingReferenceNo = "RB-001",
                    LocalAuthority = "Kandy UC",
                    YearOfRevision = 2021,
                    Status = "Rejected",
                },
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
                    PlanType = "PP",
                    PlanNo = "pp-2023-001",
                    RequestingAuthorityReferenceNo = "12341234-A-01",
                    Status = "Success",
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52413,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2023-045",
                    RequestingAuthorityReferenceNo = "12341234-A-02",
                    Status = "Pending",
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52414,
                    PlanType = "FVP",
                    PlanNo = "FVP-2022-123",
                    RequestingAuthorityReferenceNo = "12341234-A-03",
                    Status = "Success",
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52415,
                    PlanType = "PP",
                    PlanNo = "PP-2021-078",
                    RequestingAuthorityReferenceNo = "12341234-A-04",
                    Status = "Pending",
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52416,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2023-099",
                    RequestingAuthorityReferenceNo = "12341234-A-05",
                    Status = "Success",
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52417,
                    PlanType = "FVP",
                    PlanNo = "FVP-2023-102",
                    RequestingAuthorityReferenceNo = "12341234-A-06",
                    Status = "Pending",
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52418,
                    PlanType = "PP",
                    PlanNo = "PP-2022-233",
                    RequestingAuthorityReferenceNo = "12341234-A-07",
                    Status = "Success",
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52419,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2023-145",
                    RequestingAuthorityReferenceNo = "12341234-A-08",
                    Status = "Pending",
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52420,
                    PlanType = "FVP",
                    PlanNo = "FVP-2022-323",
                    RequestingAuthorityReferenceNo = "12341234-A-09",
                    Status = "Success",
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52421,
                    PlanType = "PP",
                    PlanNo = "PP-2023-178",
                    RequestingAuthorityReferenceNo = "12341234-A-10",
                    Status = "Pending",
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52422,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2022-299",
                    RequestingAuthorityReferenceNo = "12341234-A-11",
                    Status = "Success",
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52423,
                    PlanType = "FVP",
                    PlanNo = "FVP-2023-202",
                    RequestingAuthorityReferenceNo = "12341234-A-12",
                    Status = "Pending",
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52424,
                    PlanType = "PP",
                    PlanNo = "PP-2022-333",
                    RequestingAuthorityReferenceNo = "12341234-A-13",
                    Status = "Success",
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52425,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2023-245",
                    RequestingAuthorityReferenceNo = "12341234-A-14",
                    Status = "Pending",
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52426,
                    PlanType = "FVP",
                    PlanNo = "FVP-2022-423",
                    RequestingAuthorityReferenceNo = "12341234-A-15",
                    Status = "Success",
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52427,
                    PlanType = "PP",
                    PlanNo = "PP-2023-278",
                    RequestingAuthorityReferenceNo = "12341234-A-16",
                    Status = "Pending",
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52428,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2022-399",
                    RequestingAuthorityReferenceNo = "12341234-A-17",
                    Status = "Success",
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52429,
                    PlanType = "FVP",
                    PlanNo = "FVP-2023-302",
                    RequestingAuthorityReferenceNo = "12341234-A-18",
                    Status = "Pending",
                },
            };
            context.LandMiscellaneousMasterFiles.AddRange(masterFiles);
            context.SaveChanges();
        }

        private static void InitializeReports(AppDbContext context)
        {
            // If there's any data, stop
            if (context.Reports.Any())
                return;

            // Add some sample reports
            var reports = new Report[]
            {
                new Report
                {
                    ReportType = "Valuation Report",
                    Description = "Annual valuation summary report",
                    Timestamp = DateTime.UtcNow.AddDays(-30),
                },
                new Report
                {
                    ReportType = "Rating Assessment",
                    Description = "Quarterly rating assessment report",
                    Timestamp = DateTime.UtcNow.AddDays(-15),
                },
                new Report
                {
                    ReportType = "Audit Report",
                    Description = "System audit report",
                    Timestamp = DateTime.UtcNow.AddDays(-7),
                },
            };

            context.Reports.AddRange(reports);
            context.SaveChanges();
        }

        private static void InitializeUsers(AppDbContext context)
        {
            //if (context.Users.Any()) return;

            Console.WriteLine("Seeding users...");

            var users = new List<User>();

            void AddUser(
                string username,
                string password,
                string name,
                string email,
                string id,
                string position,
                string division
            )
            {
                using var hmac = new System.Security.Cryptography.HMACSHA512();
                users.Add(
                    new User
                    {
                        Username = username,
                        PasswordSalt = hmac.Key,
                        PasswordHash = hmac.ComputeHash(
                            System.Text.Encoding.UTF8.GetBytes(password)
                        ),
                        EmpName = name,
                        EmpEmail = email,
                        EmpId = id,
                        Position = position,
                        AssignedDivision = division,
                    }
                );
            }

            // Add dummy users
            AddUser(
                "Jalina",
                "Jalina123",
                "Jalina Hirushan",
                "jalinahirushan@valdept.com",
                "1001V",
                "ADV",
                "Gampaha"
            );
            AddUser(
                "Akith",
                "Akith123",
                "Akith Chandinu",
                "akithchandinu@valdept.com",
                "1002V",
                "SUP",
                "Kurunegala"
            );
            AddUser(
                "Dulmini",
                "Dulmini123",
                "Samiksha Abeyweera",
                "samiksha@valdept.com",
                "1003V",
                "ADV",
                "Colombo"
            );
            AddUser(
                "Vishwa",
                "Vishwa123",
                "Vishwa Jayasankha",
                "vishwa@valdept.com",
                "1004V",
                "SUP",
                "Matara"
            );
            AddUser(
                "Rithara",
                "Rithara123",
                "Rithara Edirisinghe",
                "rithara@valdept.com",
                "1005V",
                "ADV",
                "Maradana"
            );

            context.Users.AddRange(users);
            context.SaveChanges();
            Console.WriteLine("User data seeded.");
        }

        private static void InitializeUserTasks(AppDbContext context)
        {
            if (context.UserTasks.Any())
                return;

            Console.WriteLine("Seeding user tasks...");
            var tasks = new List<UserTask>();

            void AddTask(string username, string type, bool completed, string date)
            {
                tasks.Add(
                    new UserTask
                    {
                        Username = username,
                        TaskType = type,
                        IsCompleted = completed,
                        AssignedDate = DateTime.SpecifyKind(
                            DateTime.ParseExact(date, "yyyyMMdd", null),
                            DateTimeKind.Utc
                        ),
                    }
                );
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
            if (context.MasterDataItems.Any())
                return;

            Console.WriteLine("Seeding master data...");

            var items = new List<(string Category, string Value)>
            {
                ("buildingCategory", "category1"),
                ("buildingCategory", "category2"),
                ("buildingClass", "classType1"),
                ("buildingClass", "classType2"),
                ("conviences", "type1"),
                ("conviences", "type2"),
                ("natureOfConstruction", "type1"),
                ("natureOfConstruction", "type2"),
                ("roofMaterial", "type1"),
                ("roofMaterial", "type2"),
                ("roofFrame", "type1"),
                ("roofFrame", "type2"),
                ("roofFinisher", "type1"),
                ("roofFinisher", "type2"),
                ("celing", "type1"),
                ("celing", "type2"),
                ("foundationStructure", "type1"),
                ("foundationStructure", "type2"),
                ("wallStructure", "type1"),
                ("wallStructure", "type2"),
                ("floorStructure", "type1"),
                ("floorStructure", "type2"),
                ("door", "type1"),
                ("door", "type2"),
                ("window", "type1"),
                ("window", "type2"),
                ("windowProtection", "type1"),
                ("windowProtection", "type2"),
                ("doorsBathroomAndToiletFittings", "type1"),
                ("doorsBathroomAndToiletFittings", "type2"),
                ("doorsHandRail", "type1"),
                ("doorsHandRail", "type2"),
                ("doorsPantryCupboard", "type1"),
                ("doorsPantryCupboard", "type2"),
                ("doorsOther", "type1"),
                ("doorsOther", "type2"),
                ("wallFinisher", "type1"),
                ("wallFinisher", "type2"),
                ("floorFinisher", "type1"),
                ("floorFinisher", "type2"),
                ("bathroomAndToilet", "type1"),
                ("bathroomAndToilet", "type2"),
                ("services", "type1"),
                ("services", "type2"),
            };

            context.MasterDataItems.AddRange(
                items.Select(i => new MasterDataItem { Category = i.Category, Value = i.Value })
            );

            context.SaveChanges();
            Console.WriteLine("Master data seeded.");
        }

        private static void InitializeLandAquisitionMasterFiles(AppDbContext context)
        {
            if (context.LandAquisitionMasterFiles.Any())
                return;

            var files = new List<LandAquisitionMasterFile>
            {
                new()
                {
                    MasterFileNo = 52412,
                    PlanType = "Survey Plan",
                    PlanNo = "SP-2023-001",
                    RequestingAuthorityReferenceNo = "001",
                    Status = "Success",
                },
                new()
                {
                    MasterFileNo = 52413,
                    PlanType = "Block Survey",
                    PlanNo = "BS-2023-045",
                    RequestingAuthorityReferenceNo = "002",
                    Status = "Pending",
                },
            };
            context.LandAquisitionMasterFiles.AddRange(files);
            context.SaveChanges();
        }

        private static void InitializeRequestTypes(AppDbContext context)
        {
            // If there's any data, stop
            if (context.RequestTypes.Any())
                return;

            Console.WriteLine("Seeding request types...");

            // Add request types with better sample data
            var requestTypes = new RequestType[]
            {
                new RequestType { Code = "mr", Name = "Mass Rating" },
                new RequestType { Code = "ra", Name = "Rating Assessment" },
                new RequestType { Code = "rb", Name = "Rating Building" },
                new RequestType { Code = "ro", Name = "Rating Object" },
            };
            context.RequestTypes.AddRange(requestTypes);
            context.SaveChanges();
            Console.WriteLine("Request types seeded.");
        }

        private static void InitializeRequests(AppDbContext context)
        {
            // If there's any data, stop
            if (context.Requests.Any())
                return;

            Console.WriteLine("Seeding requests...");

            // Get request types for foreign key references
            var requestTypes = context.RequestTypes.ToList();
            if (!requestTypes.Any())
            {
                Console.WriteLine("No request types found. Requests seeding skipped.");
                return;
            }

            // Add sample requests
            var requests = new Request[]
            {
                new Request
                {
                    RequestTypeId = requestTypes.First(rt => rt.Code == "mr").Id,
                    RatingReferenceNo = "MR-2024-001",
                    LocalAuthority = "Colombo Municipal Council",
                    YearOfRevision = 2024,
                    Status = true, // success
                    CreatedAt = DateTime.UtcNow.AddDays(-30),
                    UpdatedAt = DateTime.UtcNow.AddDays(-25),
                },
                new Request
                {
                    RequestTypeId = requestTypes.First(rt => rt.Code == "ra").Id,
                    RatingReferenceNo = "RA-2024-001",
                    LocalAuthority = "Galle Municipal Council",
                    YearOfRevision = 2024,
                    Status = false, // pending
                    CreatedAt = DateTime.UtcNow.AddDays(-20),
                    UpdatedAt = DateTime.UtcNow.AddDays(-15),
                },
                new Request
                {
                    RequestTypeId = requestTypes.First(rt => rt.Code == "rb").Id,
                    RatingReferenceNo = "RB-2024-001",
                    LocalAuthority = "Kandy Municipal Council",
                    YearOfRevision = 2024,
                    Status = true, // success
                    CreatedAt = DateTime.UtcNow.AddDays(-15),
                    UpdatedAt = DateTime.UtcNow.AddDays(-10),
                },
                new Request
                {
                    RequestTypeId = requestTypes.First(rt => rt.Code == "mr").Id,
                    RatingReferenceNo = "MR-2023-005",
                    LocalAuthority = "Negombo Municipal Council",
                    YearOfRevision = 2023,
                    Status = true, // success
                    CreatedAt = DateTime.UtcNow.AddDays(-50),
                    UpdatedAt = DateTime.UtcNow.AddDays(-45),
                },
                new Request
                {
                    RequestTypeId = requestTypes.First(rt => rt.Code == "ro").Id,
                    RatingReferenceNo = "RO-2024-002",
                    LocalAuthority = "Matara Municipal Council",
                    YearOfRevision = 2024,
                    Status = false, // pending
                    CreatedAt = DateTime.UtcNow.AddDays(-10),
                    UpdatedAt = DateTime.UtcNow.AddDays(-5),
                },
                new Request
                {
                    RequestTypeId = requestTypes.First(rt => rt.Code == "ra").Id,
                    RatingReferenceNo = "RA-2023-010",
                    LocalAuthority = "Panadura Urban Council",
                    YearOfRevision = 2023,
                    Status = true, // success
                    CreatedAt = DateTime.UtcNow.AddDays(-60),
                    UpdatedAt = DateTime.UtcNow.AddDays(-55),
                },
            };
            context.Requests.AddRange(requests);
            context.SaveChanges();
            Console.WriteLine("Requests seeded.");
        }

        private static void InitializeAssets(AppDbContext context)
        {
            // If there's any data, stop
            if (context.Assets.Any())
                return;

            Console.WriteLine("Seeding assets...");

            // Get requests for foreign key references
            var requests = context.Requests.ToList();
            if (!requests.Any())
            {
                Console.WriteLine("No requests found. Assets seeding skipped.");
                return;
            }

            // Add sample assets
            var assets = new Asset[]
            {
                new Asset
                {
                    RequestId = requests[0].Id,
                    AssetNo = "AST-001-2024",
                    Ward = "Ward 01",
                    RdSt = "Galle Road",
                    Description = PropertyType.CommercialProperty,
                    Owner = "John Doe",
                    IsRatingCard = true,
                    CreatedAt = DateTime.UtcNow.AddDays(-25),
                    UpdatedAt = DateTime.UtcNow.AddDays(-20),
                },
                new Asset
                {
                    RequestId = requests[0].Id,
                    AssetNo = "AST-002-2024",
                    Ward = "Ward 01",
                    RdSt = "Main Street",
                    Description = PropertyType.ResidentialProperty,
                    Owner = "Jane Smith",
                    IsRatingCard = false,
                    CreatedAt = DateTime.UtcNow.AddDays(-25),
                    UpdatedAt = DateTime.UtcNow.AddDays(-20),
                },
                new Asset
                {
                    RequestId = requests[1].Id,
                    AssetNo = "AST-003-2024",
                    Ward = "Ward 02",
                    RdSt = "Temple Road",
                    Description = PropertyType.CommercialProperty,
                    Owner = "ABC Company Ltd",
                    IsRatingCard = true,
                    CreatedAt = DateTime.UtcNow.AddDays(-15),
                    UpdatedAt = DateTime.UtcNow.AddDays(-10),
                },
                new Asset
                {
                    RequestId = requests[1].Id,
                    AssetNo = "AST-004-2024",
                    Ward = "Ward 02",
                    RdSt = "Park Avenue",
                    Description = PropertyType.ResidentialProperty,
                    Owner = "Michael Johnson",
                    IsRatingCard = false,
                    CreatedAt = DateTime.UtcNow.AddDays(-15),
                    UpdatedAt = DateTime.UtcNow.AddDays(-10),
                },
                new Asset
                {
                    RequestId = requests[2].Id,
                    AssetNo = "AST-005-2024",
                    Ward = "Ward 03",
                    RdSt = "Hill Street",
                    Description = PropertyType.CommercialProperty,
                    Owner = "XYZ Holdings",
                    IsRatingCard = true,
                    CreatedAt = DateTime.UtcNow.AddDays(-10),
                    UpdatedAt = DateTime.UtcNow.AddDays(-5),
                },
                new Asset
                {
                    RequestId = requests[2].Id,
                    AssetNo = "AST-006-2024",
                    Ward = "Ward 03",
                    RdSt = "Lake Road",
                    Description = PropertyType.ResidentialProperty,
                    Owner = "Sarah Williams",
                    IsRatingCard = false,
                    CreatedAt = DateTime.UtcNow.AddDays(-10),
                    UpdatedAt = DateTime.UtcNow.AddDays(-5),
                },
                new Asset
                {
                    RequestId = requests[3].Id,
                    AssetNo = "AST-007-2023",
                    Ward = "Ward 04",
                    RdSt = "Beach Road",
                    Description = PropertyType.CommercialProperty,
                    Owner = "Seaside Resort Ltd",
                    IsRatingCard = true,
                    CreatedAt = DateTime.UtcNow.AddDays(-45),
                    UpdatedAt = DateTime.UtcNow.AddDays(-40),
                },
                new Asset
                {
                    RequestId = requests[3].Id,
                    AssetNo = "AST-008-2023",
                    Ward = "Ward 04",
                    RdSt = "Coconut Grove",
                    Description = PropertyType.ResidentialProperty,
                    Owner = "David Brown",
                    IsRatingCard = false,
                    CreatedAt = DateTime.UtcNow.AddDays(-45),
                    UpdatedAt = DateTime.UtcNow.AddDays(-40),
                },
                new Asset
                {
                    RequestId = requests[4].Id,
                    AssetNo = "AST-009-2024",
                    Ward = "Ward 05",
                    RdSt = "Market Street",
                    Description = PropertyType.CommercialProperty,
                    Owner = "Central Market Corp",
                    IsRatingCard = true,
                    CreatedAt = DateTime.UtcNow.AddDays(-5),
                    UpdatedAt = DateTime.UtcNow.AddDays(-2),
                },
                new Asset
                {
                    RequestId = requests[4].Id,
                    AssetNo = "AST-010-2024",
                    Ward = "Ward 05",
                    RdSt = "Garden Lane",
                    Description = PropertyType.ResidentialProperty,
                    Owner = "Lisa Anderson",
                    IsRatingCard = false,
                    CreatedAt = DateTime.UtcNow.AddDays(-5),
                    UpdatedAt = DateTime.UtcNow.AddDays(-2),
                },
                new Asset
                {
                    RequestId = requests[5].Id,
                    AssetNo = "AST-011-2023",
                    Ward = "Ward 06",
                    RdSt = "School Road",
                    Description = PropertyType.CommercialProperty,
                    Owner = "Education Center Ltd",
                    IsRatingCard = true,
                    CreatedAt = DateTime.UtcNow.AddDays(-55),
                    UpdatedAt = DateTime.UtcNow.AddDays(-50),
                },
                new Asset
                {
                    RequestId = requests[5].Id,
                    AssetNo = "AST-012-2023",
                    Ward = "Ward 06",
                    RdSt = "Flower Street",
                    Description = PropertyType.ResidentialProperty,
                    Owner = "Robert Wilson",
                    IsRatingCard = false,
                    CreatedAt = DateTime.UtcNow.AddDays(-55),
                    UpdatedAt = DateTime.UtcNow.AddDays(-50),
                },
            };
            context.Assets.AddRange(assets);
            context.SaveChanges();
            Console.WriteLine("Assets seeded.");
        }

        private static void InitializePropertyCategories(AppDbContext context)
        {
            // If there's any data, stop
            if (context.PropertyCategories.Any())
                return;

            Console.WriteLine("Seeding property categories..."); // Add the specified property categories
            var propertyCategories = new PropertyCategory[]
            {
                new PropertyCategory { Name = "Domestic" },
                new PropertyCategory { Name = "Offices" },
                new PropertyCategory { Name = "Shops" },
                new PropertyCategory { Name = "Agriculture" },
                new PropertyCategory { Name = "Special" },
            };

            context.PropertyCategories.AddRange(propertyCategories);
            context.SaveChanges();
            Console.WriteLine("Property categories seeded.");
        }
        
        private static void InitializeAssetDivisions(AppDbContext context)
        {
            // If there's any data, stop
            if (context.AssetDivisions.Any())
                return;

            Console.WriteLine("Seeding asset divisions...");

            // Add dummy records
            var assetDivisions = new AssetDivision[]
            {
                new AssetDivision
                {
                    AssetId = 1,
                    NewAssetNo = "ASSET-001-A",
                    Area = 1500.50M,                    LandType = "Residential",
                    Description = "North portion of original asset",
                    CreatedAt = DateTime.UtcNow.AddDays(-30),
                },
                new AssetDivision
                {
                    AssetId = 1,
                    NewAssetNo = "ASSET-001-B",
                    Area = 1200.75M,                    LandType = "Commercial",
                    Description = "South portion of original asset",
                    CreatedAt = DateTime.UtcNow.AddDays(-30),
                },
                new AssetDivision
                {
                    AssetId = 2,
                    NewAssetNo = "ASSET-002-A",
                    Area = 800.25M,                    LandType = "Agricultural",
                    Description = "Eastern division of farmland",
                    CreatedAt = DateTime.UtcNow.AddDays(-15),
                },
                new AssetDivision
                {
                    AssetId = 2,
                    NewAssetNo = "ASSET-002-B",
                    Area = 750.00M,
                    LandType = "Agricultural",                    Description = "Western division of farmland",
                    CreatedAt = DateTime.UtcNow.AddDays(-15),
                },
                new AssetDivision
                {
                    AssetId = 3,
                    NewAssetNo = "ASSET-003-A",
                    Area = 2000.00M,                    LandType = "Industrial",
                    Description = "Factory zone partition",
                    CreatedAt = DateTime.UtcNow.AddDays(-7),
                }
            };

            context.AssetDivisions.AddRange(assetDivisions);
            context.SaveChanges();
            Console.WriteLine("Asset divisions seeded.");
        }

        private static void InitializeReconciliations(AppDbContext context)
        {
            // If there's any data, stop
            if (context.Reconciliations.Any())
                return;

            Console.WriteLine("Seeding reconciliations...");

            var reconciliations = new Reconciliation[]
            {
                new Reconciliation
                {
                    AssetId = 1, // References AST-001-2024
                    StreetName = "Galle Road",                    ObsoleteNo = "123/A",
                    NewNo = "456/B",
                    UpdatedAt = DateTime.UtcNow.AddDays(-20),
                },
                new Reconciliation
                {
                    AssetId = 2, // References AST-002-2024
                    StreetName = "Main Street",                    ObsoleteNo = "45",
                    NewNo = "45/1",
                    UpdatedAt = DateTime.UtcNow.AddDays(-18),
                },
                new Reconciliation
                {
                    AssetId = 3, // References AST-003-2024
                    StreetName = "Temple Road",                    ObsoleteNo = "78/B",
                    NewNo = "78/B/1",
                    UpdatedAt = DateTime.UtcNow.AddDays(-15),
                },
                new Reconciliation
                {
                    AssetId = 5, // References AST-005-2024
                    StreetName = "Hill Street",                    ObsoleteNo = "25",
                    NewNo = "25A",
                    UpdatedAt = DateTime.UtcNow.AddDays(-10),
                },
                new Reconciliation
                {
                    AssetId = 7, // References AST-007-2023
                    StreetName = "Beach Road",                    ObsoleteNo = "100",
                    NewNo = "100/1-A",
                    UpdatedAt = DateTime.UtcNow.AddDays(-5),
                }
            };

            context.Reconciliations.AddRange(reconciliations);
            context.SaveChanges();
            Console.WriteLine("Reconciliations seeded.");
        }
    }
}
