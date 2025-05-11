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
            
            // Initialize Reports
            InitializeReports(context);
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
            };            context.LandMiscellaneousMasterFiles.AddRange(masterFiles);
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
                    Timestamp = DateTime.UtcNow.AddDays(-30)
                },
                new Report
                {
                    ReportType = "Rating Assessment",
                    Description = "Quarterly rating assessment report",
                    Timestamp = DateTime.UtcNow.AddDays(-15)
                },
                new Report
                {
                    ReportType = "Audit Report",
                    Description = "System audit report",
                    Timestamp = DateTime.UtcNow.AddDays(-7)
                }
            };

            context.Reports.AddRange(reports);
            context.SaveChanges();
        }
    }
}