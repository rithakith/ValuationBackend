using System;
using System.Collections.Generic;
using System.Linq;
using ValuationBackend.Data; // Assuming AppDbContext and other models are here
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

            // Get assets for foreign key references, filtered for residential properties
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

            // Helper function to create a rating card with comprehensive details
            void AddRatingCard(
                Asset asset,
                string? wallType,
                string? floorType,
                string? convenienceType,
                string? conditionType,
                int? age,
                string? accessType,
                string? subCategory,
                string? propertyType, // This corresponds to DomesticRatingCard.PropertyType
                decimal? rentPM = null,
                decimal? suggestedRate = null,
                string? plantations = null,
                string? tsBop = null,
                string? parkingSpace = null,
                DateTime? date = null,
                string? occupier = null,
                string? terms = null,
                string? notes = null
            )
            {
                // Generate new number
                string newNumberBase = $"DRC-{asset.AssetNo}";
                var existingCountForAsset = ratingCards.Count(rc => rc.AssetId == asset.Id);
                string newNumber = $"{newNumberBase}-{(existingCountForAsset + 1):D3}";


                ratingCards.Add(
                    new DomesticRatingCard
                    {
                        AssetId = asset.Id,
                        NewNumber = newNumber,
                        Owner = asset.Owner,
                        // Description from asset is general (e.g. "ResidentialProperty"),
                        // The card's description can be more specific or can use the PropertyType field.
                        // For DomesticRatingCard, the 'Description' field might be intended for textual notes,
                        // while 'PropertyType' field on the card stores "Residential", "Mixed Use" etc.
                        // Let's use the asset's description string for the card's description for now,
                        // or consider if it should be a more specific description or if the card's PropertyType field suffices.
                        Description = asset.Description.ToString(), // Or a more specific description
                        SelectWalls = wallType,
                        Floor = floorType,
                        Conveniences = convenienceType,
                        Condition = conditionType,
                        Age = age,
                        Access = accessType,
                        WardNumber = asset.Ward,
                        RoadName = asset.RdSt,
                        PropertySubCategory = subCategory,
                        PropertyType = propertyType, // Specific type for the card (e.g., "Residential", "Mixed Use")
                        RentPM = rentPM,
                        SuggestedRate = suggestedRate,
                        Plantations = plantations,
                        TsBop = tsBop,
                        ParkingSpace = parkingSpace,
                        Date = date,
                        Occupier = occupier,
                        Terms = terms,
                        Notes = notes,
                        CreatedAt = DateTime.UtcNow,
                    }
                );
            }

            // Add sample rating cards for residential properties based on AssetNo
            // This loop will iterate through all residential assets found
            foreach (var asset in assets)
            {
                // Single Family Homes examples
                if (asset.AssetNo.Contains("AST-002") || asset.AssetNo.Contains("AST-004-2024") || asset.AssetNo.Contains("AST-008")) // Made AssetNo more specific for AST-004
                {
                    AddRatingCard(
                        asset,
                        wallType: "Brick",
                        floorType: "Tile",
                        convenienceType: "Modern",
                        conditionType: "Good",
                        age: 10,
                        accessType: "Road",
                        subCategory: "Single Family",
                        propertyType: "Residential", // Card's property type
                        rentPM: 1500.00m,
                        suggestedRate: 2000.00m,
                        plantations: "Small garden with ornamental plants",
                        tsBop: "Mid-terrace property",
                        parkingSpace: "On-street parking",
                        date: DateTime.UtcNow.AddDays(-15),
                        occupier: "Owner-occupied",
                        terms: "Freehold",
                        notes: "Property features newly installed double glazing throughout"
                    );

                    // Add additional rating card for AST-002 (example of multiple cards for one asset)
                    if (asset.AssetNo.Contains("AST-002")) // Be specific with AssetNo
                    {
                        AddRatingCard(
                            asset,
                            wallType: "Brick",
                            floorType: "Tile",
                            convenienceType: "Luxury",
                            conditionType: "Good",
                            age: 8,
                            accessType: "Road",
                            subCategory: "Single Family",
                            propertyType: "Mixed Use", // Card's property type
                            rentPM: 2800.00m,
                            suggestedRate: 3500.00m,
                            plantations: "Large landscaped garden",
                            tsBop: "End of terrace with extension",
                            parkingSpace: "Double garage",
                            date: DateTime.UtcNow.AddDays(-10),
                            occupier: "Smith Family",
                            terms: "Annual lease",
                            notes: "Ground floor converted for office use, high-end residential on upper floors"
                        );
                    }
                }

                // Apartment example (if an asset matches this general pattern)
                if (asset.AssetNo.Contains("AST-006") || asset.AssetNo.Contains("AST-010")) // Example AssetNos
                {
                    AddRatingCard(
                        asset,
                        wallType: "Concrete",
                        floorType: "Tile",
                        convenienceType: "Modern",
                        conditionType: "Good",
                        age: 5,
                        accessType: "Road",
                        subCategory: "Apartment",
                        propertyType: "Residential", // Card's property type
                        rentPM: 1800.00m,
                        suggestedRate: 2200.00m,
                        plantations: "Communal garden area",
                        tsBop: "Third floor with balcony",
                        parkingSpace: "Designated parking spot",
                        date: DateTime.UtcNow.AddDays(-20),
                        occupier: "Johnson family",
                        terms: "6-month tenancy",
                        notes: "Apartment complex features gym and swimming pool facilities"
                    );
                }

                // Townhouse properties example
                if (asset.AssetNo.Contains("AST-012")) // Example AssetNo
                {
                    AddRatingCard(
                        asset,
                        wallType: "Concrete",
                        floorType: "Wood",
                        convenienceType: "Luxury",
                        conditionType: "Good",
                        age: 3,
                        accessType: "Road",
                        subCategory: "Townhouse",
                        propertyType: "Residential", // Card's property type
                        rentPM: 2200.00m,
                        suggestedRate: 2700.00m,
                        plantations: "Small private garden",
                        tsBop: "End unit in a row of 5",
                        parkingSpace: "Carport for 2 vehicles",
                        date: DateTime.UtcNow.AddDays(-5),
                        occupier: "Wilson family",
                        terms: "Annual lease",
                        notes: "Modern townhouse with energy-efficient features"
                    );

                    // Add a second card for the same townhouse with different condition/use
                    AddRatingCard(
                        asset,
                        wallType: "Wood", // Changed for variation
                        floorType: "Wood",
                        convenienceType: "Basic",
                        conditionType: "Fair",
                        age: 15,
                        accessType: "Lane",
                        subCategory: "Townhouse",
                        propertyType: "Mixed Use", // Card's property type
                        rentPM: 1200.00m,
                        suggestedRate: 1500.00m,
                        plantations: "Neglected garden area",
                        tsBop: "Mid-terrace position",
                        parkingSpace: "Street parking only",
                        date: DateTime.UtcNow.AddDays(-25),
                        occupier: "Previous tenant vacated",
                        terms: "Month-to-month",
                        notes: "Property requires significant renovation, ground floor previously used as retail space"
                    );
                }
            }

            // Add extra comprehensive examples for specific assets if they exist
            // These are outside the main loop to target specific AssetNos explicitly.

            var detailedAsset004 = assets.FirstOrDefault(a => a.AssetNo == "AST-004-2024"); // Specific AssetNo
            if (detailedAsset004 != null)
            {
                AddRatingCard(
                    detailedAsset004,
                    wallType: "Concrete",
                    floorType: "Tile",
                    convenienceType: "Luxury",
                    conditionType: "Good",
                    age: 7,
                    accessType: "Road",
                    subCategory: "Single Family",
                    propertyType: "Residential",
                    rentPM: 2500.00m,
                    suggestedRate: 3200.00m,
                    plantations: "Extensive landscaped garden with mature trees and koi pond",
                    tsBop: "Premium corner plot with 270-degree views",
                    parkingSpace: "Triple garage with electric vehicle charging points",
                    date: DateTime.UtcNow.AddMonths(-2),
                    occupier: "High-profile tenant: Local celebrity",
                    terms: "3-year fixed term lease with annual reviews",
                    notes: "Executive property with high-end finishes, smart home technology throughout, security system, and dedicated home office space"
                );
            }

            var conditionAsset010 = assets.FirstOrDefault(a => a.AssetNo == "AST-010-2024"); // Specific AssetNo
            if (conditionAsset010 != null)
            {
                // Poor condition property
                AddRatingCard(
                    conditionAsset010,
                    wallType: "Wood",
                    floorType: "Concrete",
                    convenienceType: "Basic",
                    conditionType: "Poor",
                    age: 25,
                    accessType: "Path",
                    subCategory: "Single Family",
                    propertyType: "Residential",
                    rentPM: 800.00m,
                    suggestedRate: 1000.00m,
                    plantations: "Overgrown garden with invasive species",
                    tsBop: "Remote location with limited access",
                    parkingSpace: "No designated parking",
                    date: DateTime.UtcNow.AddYears(-1),
                    occupier: "Vacant",
                    terms: "Previously month-to-month",
                    notes: "Property requires complete renovation. Structural issues evident. Damp problems throughout."
                );
            }
            
            // Note: The original dev-rithara branch had many more specific examples for AST-011, AST-009, AST-007, AST-005, AST-003, AST-001.
            // I'm including a few more as per the pattern for brevity, but you can add all of them back if needed.
            // Ensure AssetNos match exactly what's in your Assets table for these to be picked up.

            var luxuryAsset011 = assets.FirstOrDefault(a => a.AssetNo == "AST-011-2023");
            if (luxuryAsset011 != null)
            {
                 AddRatingCard(
                    luxuryAsset011,
                    "Concrete", "Wood", "Luxury", "Good", 3, "Road", "Apartment", "Residential",
                    5000.00m, 6200.00m, "Rooftop garden with exotic plants and irrigation system",
                    "Penthouse with 360-degree views", "Secure underground parking with 3 allocated spaces and EV charging",
                    DateTime.UtcNow.AddDays(-5), "High-net-worth professional", "2-year lease with 6 months paid in advance",
                    "Premium property with concierge service, private elevator, home automation system, and designer fittings throughout. Swimming pool access and gym membership included."
                );
            }

            var heritageAsset009 = assets.FirstOrDefault(a => a.AssetNo == "AST-009-2024");
            if (heritageAsset009 != null)
            {
                AddRatingCard(
                    heritageAsset009,
                    "Brick", "Wood", "Modern", "Good", 120, "Lane", "Single Family", "Residential",
                    3200.00m, 4000.00m, "Heritage garden with protected ancient trees",
                    "Grade II listed building with conservation restrictions", "Carriage house converted to garage for 2 vehicles",
                    DateTime.UtcNow.AddMonths(-6), "Mr. & Mrs. Thompson (long-term tenants)", "Protected tenancy with heritage maintenance obligations",
                    "Property has significant historical value with original features including cornicing, fireplace, and oak staircase. Refurbished to modern standards while preserving character. Energy efficiency rating affected by conservation restrictions."
                );
            }


            context.DomesticRatingCards.AddRange(ratingCards);
            context.SaveChanges();
            
            Console.WriteLine($"Domestic rating cards seeded successfully: {ratingCards.Count} records created.");
        }
    }
}