using ValuationBackend.Models;

namespace ValuationBackend.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Ensure DB is created
            context.Database.EnsureCreated();

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
    }
}