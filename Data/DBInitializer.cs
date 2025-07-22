using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
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

                // Update existing UserTasks with work item assignments
                UpdateUserTaskAssignments(context);

                // Update UserTasks with correct User IDs
                UpdateUserTaskUserIds(context);

                // Remove UserTasks that are not LM (Land Miscellaneous) - COMMENTED OUT to keep LA and MR tasks
                // RemoveNonLMUserTasks(context);

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
            // Check if we already have the new records (we expect 98 total records)
            if (context.LandMiscellaneousMasterFiles.Count() >= 98)
                return;

            // Remove all existing records to ensure clean seeding
            if (context.LandMiscellaneousMasterFiles.Any())
            {
                context.LandMiscellaneousMasterFiles.RemoveRange(context.LandMiscellaneousMasterFiles);
                context.SaveChanges();
            }

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
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52413,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2023-045",
                    RequestingAuthorityReferenceNo = "12341234-A-02",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52414,
                    PlanType = "FVP",
                    PlanNo = "FVP-2022-123",
                    RequestingAuthorityReferenceNo = "12341234-A-03",
                    Status = "Success",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52415,
                    PlanType = "PP",
                    PlanNo = "PP-2021-078",
                    RequestingAuthorityReferenceNo = "12341234-A-04",
                    Status = "Pending",
                    Lots = 4
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52416,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2023-099",
                    RequestingAuthorityReferenceNo = "12341234-A-05",
                    Status = "Success",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52417,
                    PlanType = "FVP",
                    PlanNo = "FVP-2023-102",
                    RequestingAuthorityReferenceNo = "12341234-A-06",
                    Status = "Pending",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52418,
                    PlanType = "PP",
                    PlanNo = "PP-2022-233",
                    RequestingAuthorityReferenceNo = "12341234-A-07",
                    Status = "Success",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52419,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2023-145",
                    RequestingAuthorityReferenceNo = "12341234-A-08",
                    Status = "Pending",
                    Lots = 5
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52420,
                    PlanType = "FVP",
                    PlanNo = "FVP-2022-323",
                    RequestingAuthorityReferenceNo = "12341234-A-09",
                    Status = "Success",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52421,
                    PlanType = "PP",
                    PlanNo = "PP-2023-178",
                    RequestingAuthorityReferenceNo = "12341234-A-10",
                    Status = "Pending",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52422,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2022-299",
                    RequestingAuthorityReferenceNo = "12341234-A-11",
                    Status = "Success",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52423,
                    PlanType = "FVP",
                    PlanNo = "FVP-2023-202",
                    RequestingAuthorityReferenceNo = "12341234-A-12",
                    Status = "Pending",
                    Lots = 4
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52424,
                    PlanType = "PP",
                    PlanNo = "PP-2022-333",
                    RequestingAuthorityReferenceNo = "12341234-A-13",
                    Status = "Success",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52425,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2023-245",
                    RequestingAuthorityReferenceNo = "12341234-A-14",
                    Status = "Pending",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52426,
                    PlanType = "FVP",
                    PlanNo = "FVP-2022-423",
                    RequestingAuthorityReferenceNo = "12341234-A-15",
                    Status = "Success",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52427,
                    PlanType = "PP",
                    PlanNo = "PP-2023-278",
                    RequestingAuthorityReferenceNo = "12341234-A-16",
                    Status = "Pending",
                    Lots = 5
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52428,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2022-399",
                    RequestingAuthorityReferenceNo = "12341234-A-17",
                    Status = "Success",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52429,
                    PlanType = "FVP",
                    PlanNo = "FVP-2023-302",
                    RequestingAuthorityReferenceNo = "12341234-A-18",
                    Status = "Pending",
                    Lots = 3
                },
                // Additional 30 records for users 1-5
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52430,
                    PlanType = "PP",
                    PlanNo = "PP-2023-401",
                    RequestingAuthorityReferenceNo = "12341234-A-19",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52431,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2023-402",
                    RequestingAuthorityReferenceNo = "12341234-A-20",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52432,
                    PlanType = "FVP",
                    PlanNo = "FVP-2023-403",
                    RequestingAuthorityReferenceNo = "12341234-A-21",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52433,
                    PlanType = "PP",
                    PlanNo = "PP-2023-404",
                    RequestingAuthorityReferenceNo = "12341234-A-22",
                    Status = "Success",
                    Lots = 4
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52434,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2023-405",
                    RequestingAuthorityReferenceNo = "12341234-A-23",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52435,
                    PlanType = "FVP",
                    PlanNo = "FVP-2023-406",
                    RequestingAuthorityReferenceNo = "12341234-A-24",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52436,
                    PlanType = "PP",
                    PlanNo = "PP-2023-407",
                    RequestingAuthorityReferenceNo = "12341234-A-25",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52437,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2023-408",
                    RequestingAuthorityReferenceNo = "12341234-A-26",
                    Status = "Success",
                    Lots = 5
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52438,
                    PlanType = "FVP",
                    PlanNo = "FVP-2023-409",
                    RequestingAuthorityReferenceNo = "12341234-A-27",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52439,
                    PlanType = "PP",
                    PlanNo = "PP-2023-410",
                    RequestingAuthorityReferenceNo = "12341234-A-28",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52440,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2023-411",
                    RequestingAuthorityReferenceNo = "12341234-A-29",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52441,
                    PlanType = "FVP",
                    PlanNo = "FVP-2023-412",
                    RequestingAuthorityReferenceNo = "12341234-A-30",
                    Status = "Success",
                    Lots = 4
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52442,
                    PlanType = "PP",
                    PlanNo = "PP-2023-413",
                    RequestingAuthorityReferenceNo = "12341234-A-31",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52443,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2023-414",
                    RequestingAuthorityReferenceNo = "12341234-A-32",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52444,
                    PlanType = "FVP",
                    PlanNo = "FVP-2023-415",
                    RequestingAuthorityReferenceNo = "12341234-A-33",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52445,
                    PlanType = "PP",
                    PlanNo = "PP-2023-416",
                    RequestingAuthorityReferenceNo = "12341234-A-34",
                    Status = "Success",
                    Lots = 5
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52446,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2023-417",
                    RequestingAuthorityReferenceNo = "12341234-A-35",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52447,
                    PlanType = "FVP",
                    PlanNo = "FVP-2023-418",
                    RequestingAuthorityReferenceNo = "12341234-A-36",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52448,
                    PlanType = "PP",
                    PlanNo = "PP-2023-419",
                    RequestingAuthorityReferenceNo = "12341234-A-37",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52449,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2023-420",
                    RequestingAuthorityReferenceNo = "12341234-A-38",
                    Status = "Success",
                    Lots = 4
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52450,
                    PlanType = "FVP",
                    PlanNo = "FVP-2023-421",
                    RequestingAuthorityReferenceNo = "12341234-A-39",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52451,
                    PlanType = "PP",
                    PlanNo = "PP-2023-422",
                    RequestingAuthorityReferenceNo = "12341234-A-40",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52452,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2023-423",
                    RequestingAuthorityReferenceNo = "12341234-A-41",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52453,
                    PlanType = "FVP",
                    PlanNo = "FVP-2023-424",
                    RequestingAuthorityReferenceNo = "12341234-A-42",
                    Status = "Success",
                    Lots = 5
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52454,
                    PlanType = "PP",
                    PlanNo = "PP-2023-425",
                    RequestingAuthorityReferenceNo = "12341234-A-43",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52455,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2023-426",
                    RequestingAuthorityReferenceNo = "12341234-A-44",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52456,
                    PlanType = "FVP",
                    PlanNo = "FVP-2023-427",
                    RequestingAuthorityReferenceNo = "12341234-A-45",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52457,
                    PlanType = "PP",
                    PlanNo = "PP-2023-428",
                    RequestingAuthorityReferenceNo = "12341234-A-46",
                    Status = "Success",
                    Lots = 4
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52458,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2023-429",
                    RequestingAuthorityReferenceNo = "12341234-A-47",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52459,
                    PlanType = "FVP",
                    PlanNo = "FVP-2023-430",
                    RequestingAuthorityReferenceNo = "12341234-A-48",
                    Status = "Success",
                    Lots = 3
                },
                
                // Additional 50 records (52460-52509) for more variety
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52460,
                    PlanType = "PP",
                    PlanNo = "PP-2024-001",
                    RequestingAuthorityReferenceNo = "12341234-B-01",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52461,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2024-002",
                    RequestingAuthorityReferenceNo = "12341234-B-02",
                    Status = "Success",
                    Lots = 4
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52462,
                    PlanType = "FVP",
                    PlanNo = "FVP-2024-003",
                    RequestingAuthorityReferenceNo = "12341234-B-03",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52463,
                    PlanType = "PP",
                    PlanNo = "PP-2024-004",
                    RequestingAuthorityReferenceNo = "12341234-B-04",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52464,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2024-005",
                    RequestingAuthorityReferenceNo = "12341234-B-05",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52465,
                    PlanType = "FVP",
                    PlanNo = "FVP-2024-006",
                    RequestingAuthorityReferenceNo = "12341234-B-06",
                    Status = "Success",
                    Lots = 5
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52466,
                    PlanType = "PP",
                    PlanNo = "PP-2024-007",
                    RequestingAuthorityReferenceNo = "12341234-B-07",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52467,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2024-008",
                    RequestingAuthorityReferenceNo = "12341234-B-08",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52468,
                    PlanType = "FVP",
                    PlanNo = "FVP-2024-009",
                    RequestingAuthorityReferenceNo = "12341234-B-09",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52469,
                    PlanType = "PP",
                    PlanNo = "PP-2024-010",
                    RequestingAuthorityReferenceNo = "12341234-B-10",
                    Status = "Success",
                    Lots = 4
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52470,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2024-011",
                    RequestingAuthorityReferenceNo = "12341234-B-11",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52471,
                    PlanType = "FVP",
                    PlanNo = "FVP-2024-012",
                    RequestingAuthorityReferenceNo = "12341234-B-12",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52472,
                    PlanType = "PP",
                    PlanNo = "PP-2024-013",
                    RequestingAuthorityReferenceNo = "12341234-B-13",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52473,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2024-014",
                    RequestingAuthorityReferenceNo = "12341234-B-14",
                    Status = "Success",
                    Lots = 5
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52474,
                    PlanType = "FVP",
                    PlanNo = "FVP-2024-015",
                    RequestingAuthorityReferenceNo = "12341234-B-15",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52475,
                    PlanType = "PP",
                    PlanNo = "PP-2024-016",
                    RequestingAuthorityReferenceNo = "12341234-B-16",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52476,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2024-017",
                    RequestingAuthorityReferenceNo = "12341234-B-17",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52477,
                    PlanType = "FVP",
                    PlanNo = "FVP-2024-018",
                    RequestingAuthorityReferenceNo = "12341234-B-18",
                    Status = "Success",
                    Lots = 4
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52478,
                    PlanType = "PP",
                    PlanNo = "PP-2024-019",
                    RequestingAuthorityReferenceNo = "12341234-B-19",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52479,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2024-020",
                    RequestingAuthorityReferenceNo = "12341234-B-20",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52480,
                    PlanType = "FVP",
                    PlanNo = "FVP-2024-021",
                    RequestingAuthorityReferenceNo = "12341234-B-21",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52481,
                    PlanType = "PP",
                    PlanNo = "PP-2024-022",
                    RequestingAuthorityReferenceNo = "12341234-B-22",
                    Status = "Success",
                    Lots = 5
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52482,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2024-023",
                    RequestingAuthorityReferenceNo = "12341234-B-23",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52483,
                    PlanType = "FVP",
                    PlanNo = "FVP-2024-024",
                    RequestingAuthorityReferenceNo = "12341234-B-24",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52484,
                    PlanType = "PP",
                    PlanNo = "PP-2024-025",
                    RequestingAuthorityReferenceNo = "12341234-B-25",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52485,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2024-026",
                    RequestingAuthorityReferenceNo = "12341234-B-26",
                    Status = "Success",
                    Lots = 4
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52486,
                    PlanType = "FVP",
                    PlanNo = "FVP-2024-027",
                    RequestingAuthorityReferenceNo = "12341234-B-27",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52487,
                    PlanType = "PP",
                    PlanNo = "PP-2024-028",
                    RequestingAuthorityReferenceNo = "12341234-B-28",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52488,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2024-029",
                    RequestingAuthorityReferenceNo = "12341234-B-29",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52489,
                    PlanType = "FVP",
                    PlanNo = "FVP-2024-030",
                    RequestingAuthorityReferenceNo = "12341234-B-30",
                    Status = "Success",
                    Lots = 5
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52490,
                    PlanType = "PP",
                    PlanNo = "PP-2024-031",
                    RequestingAuthorityReferenceNo = "12341234-B-31",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52491,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2024-032",
                    RequestingAuthorityReferenceNo = "12341234-B-32",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52492,
                    PlanType = "FVP",
                    PlanNo = "FVP-2024-033",
                    RequestingAuthorityReferenceNo = "12341234-B-33",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52493,
                    PlanType = "PP",
                    PlanNo = "PP-2024-034",
                    RequestingAuthorityReferenceNo = "12341234-B-34",
                    Status = "Success",
                    Lots = 4
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52494,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2024-035",
                    RequestingAuthorityReferenceNo = "12341234-B-35",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52495,
                    PlanType = "FVP",
                    PlanNo = "FVP-2024-036",
                    RequestingAuthorityReferenceNo = "12341234-B-36",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52496,
                    PlanType = "PP",
                    PlanNo = "PP-2024-037",
                    RequestingAuthorityReferenceNo = "12341234-B-37",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52497,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2024-038",
                    RequestingAuthorityReferenceNo = "12341234-B-38",
                    Status = "Success",
                    Lots = 5
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52498,
                    PlanType = "FVP",
                    PlanNo = "FVP-2024-039",
                    RequestingAuthorityReferenceNo = "12341234-B-39",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52499,
                    PlanType = "PP",
                    PlanNo = "PP-2024-040",
                    RequestingAuthorityReferenceNo = "12341234-B-40",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52500,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2024-041",
                    RequestingAuthorityReferenceNo = "12341234-B-41",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52501,
                    PlanType = "FVP",
                    PlanNo = "FVP-2024-042",
                    RequestingAuthorityReferenceNo = "12341234-B-42",
                    Status = "Success",
                    Lots = 4
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52502,
                    PlanType = "PP",
                    PlanNo = "PP-2024-043",
                    RequestingAuthorityReferenceNo = "12341234-B-43",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52503,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2024-044",
                    RequestingAuthorityReferenceNo = "12341234-B-44",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52504,
                    PlanType = "FVP",
                    PlanNo = "FVP-2024-045",
                    RequestingAuthorityReferenceNo = "12341234-B-45",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52505,
                    PlanType = "PP",
                    PlanNo = "PP-2024-046",
                    RequestingAuthorityReferenceNo = "12341234-B-46",
                    Status = "Success",
                    Lots = 5
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52506,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2024-047",
                    RequestingAuthorityReferenceNo = "12341234-B-47",
                    Status = "Pending",
                    Lots = 1
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52507,
                    PlanType = "FVP",
                    PlanNo = "FVP-2024-048",
                    RequestingAuthorityReferenceNo = "12341234-B-48",
                    Status = "Success",
                    Lots = 3
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52508,
                    PlanType = "PP",
                    PlanNo = "PP-2024-049",
                    RequestingAuthorityReferenceNo = "12341234-B-49",
                    Status = "Pending",
                    Lots = 2
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52509,
                    PlanType = "Cadaster",
                    PlanNo = "CAD-2024-050",
                    RequestingAuthorityReferenceNo = "12341234-B-50",
                    Status = "Success",
                    Lots = 4
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
            if (context.Users.Any()) return;

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
            // Calculate expected task count: 12 LA/MR tasks + number of LM records  
            var expectedLmTaskCount = context.LandMiscellaneousMasterFiles.Count();
            var expectedNonLmTaskCount = 12;
            var currentLmTaskCount = context.UserTasks.Count(t => t.TaskType == "LM");
            var currentNonLmTaskCount = context.UserTasks.Count(t => t.TaskType != "LM");

            // Check if we have sufficient LM tasks - only reseed LM tasks if needed
            bool needLmTasks = currentLmTaskCount < expectedLmTaskCount;
            bool needNonLmTasks = currentNonLmTaskCount < expectedNonLmTaskCount;

            if (!needLmTasks && !needNonLmTasks)
                return;

            // Only remove non-LM tasks if we need to reseed them
            if (needNonLmTasks && currentNonLmTaskCount > 0)
            {
                var nonLmTasks = context.UserTasks.Where(t => t.TaskType != "LM").ToList();
                Console.WriteLine($"Removing {nonLmTasks.Count} UserTask entries with TaskType other than 'LM'...");
                foreach (var task in nonLmTasks)
                {
                    Console.WriteLine($"Removing UserTask: Username={task.Username}, TaskType={task.TaskType}, Description={task.WorkItemDescription}");
                }
                context.UserTasks.RemoveRange(nonLmTasks);
                context.SaveChanges();
                Console.WriteLine("Non-LM UserTasks removed successfully.");
            }

            Console.WriteLine("Seeding user tasks...");
            var tasks = new List<UserTask>();

            void AddTask(string username, string type, bool completed, string date,
                        int? requestId = null, int? landAcquisitionId = null, int? landMiscellaneousId = null,
                        string? description = null, string? referenceNumber = null)
            {
                // Map usernames to specific User IDs
                var userId = username switch
                {
                    "Jalina" => 1,
                    "Akith" => 2,
                    "Dulmini" => 3,
                    "Vishwa" => 4,
                    "Rithara" => 5,
                    _ => 0 // Default for unknown users
                };

                tasks.Add(
                    new UserTask
                    {
                        Username = username,
                        UserId = userId,
                        TaskType = type,
                        IsCompleted = completed,
                        AssignedDate = DateTime.SpecifyKind(
                            DateTime.ParseExact(date, "yyyyMMdd", null),
                            DateTimeKind.Utc
                        ),
                        RequestId = requestId,
                        LandAcquisitionId = landAcquisitionId,
                        LandMiscellaneousId = landMiscellaneousId,
                        WorkItemDescription = description,
                        ReferenceNumber = referenceNumber
                    }
                );
            }

            // Add non-LM tasks only if needed
            if (needNonLmTasks)
            {
                // Non-LM tasks (LA and MR tasks without referencing old LandMiscellaneous IDs)
                // Jalina's tasks
                AddTask("Jalina", "LA", true, "20250105", landAcquisitionId: 1, description: "Land acquisition survey for Highway Project", referenceNumber: "LA-2025-001");
                AddTask("Jalina", "MR", true, "20250115", requestId: 1, description: "Mass rating assessment - Colombo MC", referenceNumber: "MR-2025-001");
                AddTask("Jalina", "LA", true, "20250301", landAcquisitionId: 2, description: "Land acquisition for Bridge Project", referenceNumber: "LA-2025-002");

                // Akith's tasks
                AddTask("Akith", "MR", true, "20250120", requestId: 2, description: "Rating assessment - Galle MC", referenceNumber: "MR-2025-002");
                AddTask("Akith", "LA", false, "20250225", landAcquisitionId: 3, description: "Land acquisition survey", referenceNumber: "LA-2025-003");

                // Dulmini's tasks
                AddTask("Dulmini", "LA", true, "20250110", landAcquisitionId: 4, description: "Land acquisition documentation", referenceNumber: "LA-2025-004");
                AddTask("Dulmini", "MR", true, "20250112", requestId: 3, description: "Rating building assessment", referenceNumber: "MR-2025-003");
                AddTask("Dulmini", "MR", false, "20250302", requestId: 1, description: "Follow-up rating assessment", referenceNumber: "MR-2025-004");

                // Vishwa's tasks
                AddTask("Vishwa", "LA", true, "20250101", landAcquisitionId: 5, description: "Land acquisition initial survey", referenceNumber: "LA-2025-005");
                AddTask("Vishwa", "LA", true, "20250215", landAcquisitionId: 6, description: "Land acquisition follow-up", referenceNumber: "LA-2025-006");
                AddTask("Vishwa", "MR", true, "20250318", requestId: 2, description: "Additional rating assessment", referenceNumber: "MR-2025-005");

                // Rithara's tasks
                AddTask("Rithara", "MR", true, "20250118", requestId: 3, description: "Building rating review", referenceNumber: "MR-2025-006");
                AddTask("Rithara", "LA", false, "20250311", landAcquisitionId: 7, description: "Land acquisition assessment", referenceNumber: "LA-2025-007");

                // Additional LA tasks for remaining Land Acquisition Master Files (IDs 8-22)
                // Distribute among all 5 users
                AddTask("Jalina", "LA", true, "20250315", landAcquisitionId: 8, description: "Land acquisition survey for Metro Line", referenceNumber: "LA-2025-008");
                AddTask("Akith", "LA", false, "20250320", landAcquisitionId: 9, description: "Land acquisition for School Development", referenceNumber: "LA-2025-009");
                AddTask("Dulmini", "LA", true, "20250325", landAcquisitionId: 10, description: "Land acquisition documentation review", referenceNumber: "LA-2025-010");
                AddTask("Vishwa", "LA", false, "20250330", landAcquisitionId: 11, description: "Land acquisition field verification", referenceNumber: "LA-2025-011");
                AddTask("Rithara", "LA", true, "20250405", landAcquisitionId: 12, description: "Land acquisition boundary survey", referenceNumber: "LA-2025-012");

                AddTask("Jalina", "LA", false, "20250410", landAcquisitionId: 13, description: "Land acquisition for Hospital Extension", referenceNumber: "LA-2025-013");
                AddTask("Akith", "LA", true, "20250415", landAcquisitionId: 14, description: "Land acquisition compensation assessment", referenceNumber: "LA-2025-014");
                AddTask("Dulmini", "LA", false, "20250420", landAcquisitionId: 15, description: "Land acquisition legal documentation", referenceNumber: "LA-2025-015");
                AddTask("Vishwa", "LA", true, "20250425", landAcquisitionId: 16, description: "Land acquisition site inspection", referenceNumber: "LA-2025-016");
                AddTask("Rithara", "LA", false, "20250430", landAcquisitionId: 17, description: "Land acquisition valuation report", referenceNumber: "LA-2025-017");

                AddTask("Jalina", "LA", true, "20250505", landAcquisitionId: 18, description: "Land acquisition for Road Widening", referenceNumber: "LA-2025-018");
                AddTask("Akith", "LA", false, "20250510", landAcquisitionId: 19, description: "Land acquisition preliminary survey", referenceNumber: "LA-2025-019");
                AddTask("Dulmini", "LA", true, "20250515", landAcquisitionId: 20, description: "Land acquisition title verification", referenceNumber: "LA-2025-020");
                AddTask("Vishwa", "LA", false, "20250520", landAcquisitionId: 21, description: "Land acquisition environmental assessment", referenceNumber: "LA-2025-021");
                AddTask("Rithara", "LA", true, "20250525", landAcquisitionId: 22, description: "Land acquisition final documentation", referenceNumber: "LA-2025-022");
            }

            // Add LM tasks only if needed
            if (needLmTasks)
            {
                // LM tasks for all current land miscellaneous records - randomly distributed
                var users = new[] { "Jalina", "Akith", "Dulmini", "Vishwa", "Rithara" };
                var planTypes = new[] { "PP", "Cadaster", "FVP" };
                var random = new Random(42); // Fixed seed for consistent results

                // Get all actual LandMiscellaneous records from database to use their real IDs
                var landMiscRecords = context.LandMiscellaneousMasterFiles.OrderBy(lm => lm.MasterFileNo).ToList();

                // Create tasks for each actual LandMiscellaneous record
                for (int i = 0; i < landMiscRecords.Count; i++)
                {
                    var record = landMiscRecords[i];
                    var randomUser = users[random.Next(users.Length)];
                    var randomPlanType = planTypes[random.Next(planTypes.Length)];
                    var isCompleted = random.Next(100) < 30; // 30% chance of being completed
                    var randomDays = random.Next(1, 120); // Random date within last 120 days
                    var assignedDate = DateTime.Today.AddDays(-randomDays).ToString("yyyyMMdd");

                    AddTask(randomUser, "LM", isCompleted, assignedDate,
                        landMiscellaneousId: record.Id, // Use the actual database ID
                        description: $"{randomPlanType} plan verification for {record.MasterFileNo}",
                        referenceNumber: $"LM-2025-{(i + 1):D3}");
                }
            }

            if (tasks.Any())
            {
                context.UserTasks.AddRange(tasks);
                context.SaveChanges();
                Console.WriteLine($"User tasks seeded. Added {tasks.Count} tasks (LM: {tasks.Count(t => t.TaskType == "LM")}, Non-LM: {tasks.Count(t => t.TaskType != "LM")}).");
            }
            else
            {
                Console.WriteLine("No new tasks needed - all UserTasks are already properly seeded.");
            }
        }

        private static void UpdateUserTaskAssignments(AppDbContext context)
        {
            // Check if any UserTasks have null reference fields (meaning they need to be updated)
            var unassignedTasks = context.UserTasks
                .Where(ut => ut.RequestId == null && ut.LandAcquisitionId == null && ut.LandMiscellaneousId == null)
                .ToList();

            if (!unassignedTasks.Any())
            {
                Console.WriteLine("All UserTasks already have work item assignments.");
                return;
            }

            Console.WriteLine($"Updating {unassignedTasks.Count} UserTask assignments...");

            // Get available work items
            var landAcquisitionIds = context.LandAquisitionMasterFiles.Select(la => la.Id).ToList();
            var landMiscellaneousIds = context.LandMiscellaneousMasterFiles.Select(lm => lm.Id).ToList();
            var requestIds = context.Requests.Select(r => r.Id).ToList();

            Console.WriteLine($"Available IDs - LA: {landAcquisitionIds.Count}, LM: {landMiscellaneousIds.Count}, Requests: {requestIds.Count}");

            // Counters for round-robin assignment
            int laIndex = 0, lmIndex = 0, mrIndex = 0;

            foreach (var task in unassignedTasks)
            {
                switch (task.TaskType)
                {
                    case "LA":
                        if (landAcquisitionIds.Any() && laIndex < landAcquisitionIds.Count)
                        {
                            task.LandAcquisitionId = landAcquisitionIds[laIndex];
                            task.WorkItemDescription = $"Land acquisition task for LA ID {landAcquisitionIds[laIndex]}";
                            task.ReferenceNumber = $"LA-2025-{(laIndex + 1):D3}";
                            laIndex++;
                        }
                        break;

                    case "LM":
                        if (landMiscellaneousIds.Any() && lmIndex < landMiscellaneousIds.Count)
                        {
                            task.LandMiscellaneousId = landMiscellaneousIds[lmIndex];
                            task.WorkItemDescription = $"Land miscellaneous task for LM ID {landMiscellaneousIds[lmIndex]}";
                            task.ReferenceNumber = $"LM-2025-{(lmIndex + 1):D3}";
                            lmIndex++;
                        }
                        break;

                    case "MR":
                        if (requestIds.Any() && mrIndex < requestIds.Count)
                        {
                            task.RequestId = requestIds[mrIndex];
                            task.WorkItemDescription = $"Mass rating task for Request ID {requestIds[mrIndex]}";
                            task.ReferenceNumber = $"MR-2025-{(mrIndex + 1):D3}";
                            mrIndex++;
                        }
                        break;
                }
            }

            context.SaveChanges();
            Console.WriteLine("UserTask assignments updated successfully.");
        }

        private static void UpdateUserTaskUserIds(AppDbContext context)
        {
            // Check if any UserTasks have incorrect User IDs
            var allUserTasks = context.UserTasks.ToList();
            var tasksToUpdate = new List<UserTask>();

            foreach (var task in allUserTasks)
            {
                var correctUserId = task.Username switch
                {
                    "Jalina" => 1,
                    "Akith" => 2,
                    "Dulmini" => 3,
                    "Vishwa" => 4,
                    "Rithara" => 5,
                    _ => 0
                };

                if (task.UserId != correctUserId)
                {
                    task.UserId = correctUserId;
                    tasksToUpdate.Add(task);
                }
            }

            if (tasksToUpdate.Any())
            {
                Console.WriteLine($"Updating {tasksToUpdate.Count} UserTask User IDs...");
                context.SaveChanges();
                Console.WriteLine("UserTask User IDs updated successfully.");
            }
            else
            {
                Console.WriteLine("All UserTasks already have correct User IDs.");
            }
        }

        private static void RemoveNonLMUserTasks(AppDbContext context)
        {
            // Get all UserTasks that are not LM (Land Miscellaneous)
            var nonLMTasks = context.UserTasks
                .Where(ut => ut.TaskType != "LM")
                .ToList();

            if (!nonLMTasks.Any())
            {
                Console.WriteLine("No non-LM UserTasks found to remove.");
                return;
            }

            Console.WriteLine($"Removing {nonLMTasks.Count} UserTask entries with TaskType other than 'LM'...");

            // Log the tasks being removed for transparency
            foreach (var task in nonLMTasks)
            {
                Console.WriteLine($"Removing UserTask: Username={task.Username}, TaskType={task.TaskType}, Description={task.WorkItemDescription}");
            }

            context.UserTasks.RemoveRange(nonLMTasks);
            context.SaveChanges();
            Console.WriteLine("Non-LM UserTasks removed successfully.");
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
            // Only seed if no requests exist
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
            var requests = new List<Request>
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
                    RequestTypeId = requestTypes.First(rt => rt.Code == "mr").Id,
                    RatingReferenceNo = "MR-2025-001",
                    LocalAuthority = "Kelaniya Municipal Council",
                    YearOfRevision = 2024,
                    Status = true, // success
                    CreatedAt = DateTime.UtcNow.AddDays(-30),
                    UpdatedAt = DateTime.UtcNow.AddDays(-25),
                },
                new Request
                {
                    RequestTypeId = requestTypes.First(rt => rt.Code == "mr").Id,
                    RatingReferenceNo = "MR-2024-010",
                    LocalAuthority = "Colombo Municipal Council",
                    YearOfRevision = 2024,
                    Status = true, // success
                    CreatedAt = DateTime.UtcNow.AddDays(-30),
                    UpdatedAt = DateTime.UtcNow.AddDays(-25),
                },
                new Request
                {
                    RequestTypeId = requestTypes.First(rt => rt.Code == "mr").Id,
                    RatingReferenceNo = "MR-2023-002",
                    LocalAuthority = "Kandy Municipal Council",
                    YearOfRevision = 2024,
                    Status = true, // success
                    CreatedAt = DateTime.UtcNow.AddDays(-30),
                    UpdatedAt = DateTime.UtcNow.AddDays(-25),
                },
                new Request
                {
                    RequestTypeId = requestTypes.First(rt => rt.Code == "mr").Id,
                    RatingReferenceNo = "MR-2024-101",
                    LocalAuthority = "Gampaha Municipal Council",
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
                // Additional dummy requests
                new Request
                {
                    RequestTypeId = requestTypes.First(rt => rt.Code == "rb").Id,
                    RatingReferenceNo = "RB-2023-002",
                    LocalAuthority = "Kurunegala Municipal Council",
                    YearOfRevision = 2023,
                    Status = false,
                    CreatedAt = DateTime.UtcNow.AddDays(-40),
                    UpdatedAt = DateTime.UtcNow.AddDays(-35),
                },
                new Request
                {
                    RequestTypeId = requestTypes.First(rt => rt.Code == "mr").Id,
                    RatingReferenceNo = "MR-2022-003",
                    LocalAuthority = "Jaffna Municipal Council",
                    YearOfRevision = 2022,
                    Status = true,
                    CreatedAt = DateTime.UtcNow.AddDays(-80),
                    UpdatedAt = DateTime.UtcNow.AddDays(-75),
                },
                new Request
                {
                    RequestTypeId = requestTypes.First(rt => rt.Code == "ra").Id,
                    RatingReferenceNo = "RA-2025-004",
                    LocalAuthority = "Batticaloa Municipal Council",
                    YearOfRevision = 2025,
                    Status = false,
                    CreatedAt = DateTime.UtcNow.AddDays(-5),
                    UpdatedAt = DateTime.UtcNow.AddDays(-2),
                },
                new Request
                {
                    RequestTypeId = requestTypes.First(rt => rt.Code == "ro").Id,
                    RatingReferenceNo = "RO-2023-005",
                    LocalAuthority = "Anuradhapura Municipal Council",
                    YearOfRevision = 2023,
                    Status = true,
                    CreatedAt = DateTime.UtcNow.AddDays(-100),
                    UpdatedAt = DateTime.UtcNow.AddDays(-90),
                },
                new Request
                {
                    RequestTypeId = requestTypes.First(rt => rt.Code == "mr").Id,
                    RatingReferenceNo = "MR-2025-006",
                    LocalAuthority = "Badulla Municipal Council",
                    YearOfRevision = 2025,
                    Status = false,
                    CreatedAt = DateTime.UtcNow.AddDays(-3),
                    UpdatedAt = DateTime.UtcNow.AddDays(-1),
                },
            };
            context.Requests.AddRange(requests);
            context.SaveChanges();
            Console.WriteLine("Requests seeded.");
            context.SaveChanges();
            Console.WriteLine("Requests seeded.");
        }

        private static void InitializeAssets(AppDbContext context)
        {
            // Only seed if no assets exist
            if (context.Assets.Any())
                return;

            Console.WriteLine("Seeding assets...");

            // Get all requests
            var allRequests = context.Requests.Include(r => r.RequestType).ToList();
            if (!allRequests.Any())
            {
                Console.WriteLine("No requests found. Assets seeding skipped.");
                return;
            }

            // Get Mass Rating requests specifically
            var massRatingRequests = allRequests.Where(r => r.RequestType.Code == "mr").OrderBy(r => r.Id).ToList();
            var otherRequests = allRequests.Where(r => r.RequestType.Code != "mr").OrderBy(r => r.Id).ToList();

            var assets = new List<Asset>();
            var assetCounter = 1;

            // Create assets for each Mass Rating request (3-5 assets per request)
            foreach (var mrRequest in massRatingRequests)
            {
                // Determine number of assets for this request (randomly between 3-5)
                var numAssets = 3 + (assetCounter % 3);

                for (int i = 0; i < numAssets; i++)
                {
                    assets.Add(new Asset
                    {
                        RequestId = mrRequest.Id,
                        AssetNo = $"AST-{assetCounter:D3}-{mrRequest.YearOfRevision}",
                        Ward = $"Ward {(assetCounter % 10) + 1:D2}",
                        RdSt = GetStreetName(assetCounter),
                        Description = (PropertyType)(assetCounter % 2),
                        Owner = GetOwnerName(assetCounter),
                        IsRatingCard = assetCounter % 3 != 0,
                        CreatedAt = mrRequest.CreatedAt.AddDays(2),
                        UpdatedAt = mrRequest.UpdatedAt,
                    });
                    assetCounter++;
                }
            }

            // Create a few assets for other request types
            foreach (var otherRequest in otherRequests.Take(3))
            {
                assets.Add(new Asset
                {
                    RequestId = otherRequest.Id,
                    AssetNo = $"AST-{assetCounter:D3}-{otherRequest.YearOfRevision}",
                    Ward = $"Ward {(assetCounter % 10) + 1:D2}",
                    RdSt = GetStreetName(assetCounter),
                    Description = PropertyType.CommercialProperty,
                    Owner = GetOwnerName(assetCounter),
                    IsRatingCard = true,
                    CreatedAt = otherRequest.CreatedAt.AddDays(2),
                    UpdatedAt = otherRequest.UpdatedAt,
                });
                assetCounter++;
            }

            context.Assets.AddRange(assets);
            context.SaveChanges();
            Console.WriteLine($"Assets seeded. Total: {assets.Count} (Mass Rating: {massRatingRequests.Sum(r => assets.Count(a => a.RequestId == r.Id))})");
        }

        private static string GetStreetName(int index)
        {
            var streets = new[] {
                "Galle Road", "Main Street", "Temple Road", "Park Avenue",
                "Hill Street", "Lake Road", "Beach Road", "Coconut Grove",
                "Market Street", "Garden Lane", "School Road", "Flower Street",
                "Station Road", "Church Street", "Hospital Road", "Bank Street",
                "Queens Road", "Kings Avenue", "Princess Street", "Duke Lane"
            };
            return streets[index % streets.Length];
        }

        private static string GetOwnerName(int index)
        {
            var firstNames = new[] {
                "John", "Jane", "Michael", "Sarah", "David", "Lisa", "Robert", "Mary",
                "James", "Patricia", "William", "Jennifer", "Richard", "Linda", "Charles", "Elizabeth"
            };
            var lastNames = new[] {
                "Doe", "Smith", "Johnson", "Williams", "Brown", "Anderson", "Wilson", "Taylor",
                "Thomas", "Jackson", "White", "Harris", "Martin", "Thompson", "Garcia", "Martinez"
            };
            var companies = new[] {
                "ABC Company Ltd", "XYZ Holdings", "Central Market Corp", "Education Center Ltd",
                "Tech Solutions Inc", "Global Traders", "Prime Investments", "Urban Developers"
            };

            // 60% individual owners, 40% companies
            if (index % 5 < 3)
            {
                return $"{firstNames[index % firstNames.Length]} {lastNames[index % lastNames.Length]}";
            }
            else
            {
                return companies[index % companies.Length];
            }
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
                    Area = 1500.50M,
                    LandType = "Residential",
                    Description = "North portion of original asset",
                    CreatedAt = DateTime.UtcNow.AddDays(-30),
                },
                new AssetDivision
                {
                    AssetId = 1,
                    NewAssetNo = "ASSET-001-B",
                    Area = 1200.75M,
                    LandType = "Commercial",
                    Description = "South portion of original asset",
                    CreatedAt = DateTime.UtcNow.AddDays(-30),
                },
                new AssetDivision
                {
                    AssetId = 2,
                    NewAssetNo = "ASSET-002-A",
                    Area = 800.25M,
                    LandType = "Agricultural",
                    Description = "Eastern division of farmland",
                    CreatedAt = DateTime.UtcNow.AddDays(-15),
                },
                new AssetDivision
                {
                    AssetId = 2,
                    NewAssetNo = "ASSET-002-B",
                    Area = 750.00M,
                    LandType = "Agricultural",
                    Description = "Western division of farmland",
                    CreatedAt = DateTime.UtcNow.AddDays(-15),
                },
                new AssetDivision
                {
                    AssetId = 3,
                    NewAssetNo = "ASSET-003-A",
                    Area = 2000.00M,
                    LandType = "Industrial",
                    Description = "Factory zone partition",
                    CreatedAt = DateTime.UtcNow.AddDays(-7),
                },
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
                    StreetName = "Galle Road",
                    ObsoleteNo = "123/A",
                    NewNo = "456/B",
                    UpdatedAt = DateTime.UtcNow.AddDays(-20),
                },
                new Reconciliation
                {
                    AssetId = 2, // References AST-002-2024
                    StreetName = "Main Street",
                    ObsoleteNo = "45",
                    NewNo = "45/1",
                    UpdatedAt = DateTime.UtcNow.AddDays(-18),
                },
                new Reconciliation
                {
                    AssetId = 3, // References AST-003-2024
                    StreetName = "Temple Road",
                    ObsoleteNo = "78/B",
                    NewNo = "78/B/1",
                    UpdatedAt = DateTime.UtcNow.AddDays(-15),
                },
                new Reconciliation
                {
                    AssetId = 5, // References AST-005-2024
                    StreetName = "Hill Street",
                    ObsoleteNo = "25",
                    NewNo = "25A",
                    UpdatedAt = DateTime.UtcNow.AddDays(-10),
                },
                new Reconciliation
                {
                    AssetId = 7, // References AST-007-2023
                    StreetName = "Beach Road",
                    ObsoleteNo = "100",
                    NewNo = "100/1-A",
                    UpdatedAt = DateTime.UtcNow.AddDays(-5),
                },
            };

            context.Reconciliations.AddRange(reconciliations);
            context.SaveChanges();
            Console.WriteLine("Reconciliations seeded.");
        }
    }
}
