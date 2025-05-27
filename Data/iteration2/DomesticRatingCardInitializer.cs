using System;
using System.Collections.Generic;
using System.Linq;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Data
{
    public static class DomesticRatingCardInitializer
    {
        public static void InitializeDomesticRatingCards(AppDbContext context)
        {
            // If there's any data, stop
            if (context.DomesticRatingCards.Any())
                return;

            Console.WriteLine("Seeding domestic rating cards...");

            // Get assets for foreign key references
            var assets = context
                .Assets.Where(a => a.Description == PropertyType.ResidentialProperty)
                .ToList();

            if (!assets.Any())
            {
                Console.WriteLine(
                    "No residential property assets found. Domestic Rating Cards seeding skipped."
                );
                return;
            }

            var ratingCards = new List<DomesticRatingCard>();

            // Add sample rating cards for first few assets
            foreach (var asset in assets.Take(5))
            {
                var newNumber = $"DRC-{asset.AssetNo}-001";

                ratingCards.Add(new DomesticRatingCard
                {
                    AssetId = asset.Id,
                    NewNumber = newNumber,
                    Owner = asset.Owner,
                    Description = asset.Description.ToString(),
                    SelectWalls = "Brick",
                    Floor = "Tile",
                    Conveniences = "Modern",
                    Condition = "Good",
                    Age = 10,
                    Access = "Road",
                    WardNumber = asset.Ward,
                    RoadName = asset.RdSt,
                    PropertySubCategory = "SingleFamily",
                    PropertyType = "Residential",
                    RentPM = 1500.00m,
                    SuggestedRate = 2000.00m,
                    Plantations = "Small garden with ornamental plants",
                    TsBop = "Mid-terrace property",
                    ParkingSpace = "On-street parking",
                    Date = DateTime.UtcNow.AddDays(-15),
                    Occupier = "Owner-occupied",
                    Terms = "Freehold",
                    Notes = "Property features newly installed double glazing throughout",
                    CreatedAt = DateTime.UtcNow
                });
            }

            context.DomesticRatingCards.AddRange(ratingCards);
            context.SaveChanges();
            
            Console.WriteLine($"Domestic rating cards seeded successfully: {ratingCards.Count} records created.");
        }
    }
}
