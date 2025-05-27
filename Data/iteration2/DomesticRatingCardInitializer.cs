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

            // Find the Domestic property category
            var domesticCategory = context.PropertyCategories.FirstOrDefault(pc =>
                pc.Name == "Domestic"
            );

            if (domesticCategory == null)
            {
                Console.WriteLine(
                    "Domestic property category not found. Domestic Rating Cards seeding skipped."
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
                string? propertyType,
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
                string newNumber = $"DRC-{asset.AssetNo}-001";

                var existingCount = ratingCards.Count(rc => rc.AssetId == asset.Id);
                if (existingCount > 0)
                {
                    newNumber = $"DRC-{asset.AssetNo}-{existingCount + 1:D3}";
                }

                ratingCards.Add(
                    new DomesticRatingCard
                    {
                        AssetId = asset.Id,
                        NewNumber = newNumber,
                        Owner = asset.Owner,
                        Description = asset.Description.ToString(),
                        SelectWalls = wallType,
                        Floor = floorType,
                        Conveniences = convenienceType,
                        Condition = conditionType,
                        Age = age,
                        Access = accessType,
                        WardNumber = asset.Ward,
                        RoadName = asset.RdSt,
                        PropertySubCategory = subCategory,
                        PropertyType = propertyType,
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

            // Add sample rating cards for residential properties
            foreach (var asset in assets)
            {
                // Single Family Homes
                if (
                    asset.AssetNo.Contains("002")
                    || asset.AssetNo.Contains("004")
                    || asset.AssetNo.Contains("008")
                )
                {
                    AddRatingCard(
                        asset,
                        "Brick",
                        "Tile",
                        "Modern",
                        "Good",
                        10,
                        "Road",
                        "Single Family",
                        "Residential",
                        1500.00m,
                        2000.00m,
                        "Small garden with ornamental plants",
                        "Mid-terrace property",
                        "On-street parking",
                        DateTime.UtcNow.AddDays(-15),
                        "Owner-occupied",
                        "Freehold",
                        "Property features newly installed double glazing throughout"
                    );

                    // Add additional rating card for AST-002
                    if (asset.AssetNo.Contains("002"))
                    {
                        AddRatingCard(
                            asset,
                            "Brick",
                            "Tile",
                            "Luxury",
                            "Good",
                            8,
                            "Road",
                            "Single Family",
                            "Mixed Use",
                            2800.00m,
                            3500.00m,
                            "Large landscaped garden",
                            "End of terrace with extension",
                            "Double garage",
                            DateTime.UtcNow.AddDays(-10),
                            "Smith Family",
                            "Annual lease",
                            "Ground floor converted for office use, high-end residential on upper floors"
                        );
                    }
                }

                // Apartment properties
                if (asset.AssetNo.Contains("006") || asset.AssetNo.Contains("010"))
                {
                    AddRatingCard(
                        asset,
                        "Concrete",
                        "Tile",
                        "Modern",
                        "Good",
                        5,
                        "Road",
                        "Apartment",
                        "Residential",
                        1800.00m,
                        2200.00m,
                        "Communal garden area",
                        "Third floor with balcony",
                        "Designated parking spot",
                        DateTime.UtcNow.AddDays(-20),
                        "Johnson family",
                        "6-month tenancy",
                        "Apartment complex features gym and swimming pool facilities"
                    );
                }

                // Townhouse properties
                if (asset.AssetNo.Contains("012"))
                {
                    AddRatingCard(
                        asset,
                        "Concrete",
                        "Wood",
                        "Luxury",
                        "Good",
                        3,
                        "Road",
                        "Townhouse",
                        "Residential",
                        2200.00m,
                        2700.00m,
                        "Small private garden",
                        "End unit in a row of 5",
                        "Carport for 2 vehicles",
                        DateTime.UtcNow.AddDays(-5),
                        "Wilson family",
                        "Annual lease",
                        "Modern townhouse with energy-efficient features"
                    );

                    // Add a second card for townhouse with different condition
                    AddRatingCard(
                        asset,
                        "Wood",
                        "Wood",
                        "Basic",
                        "Fair",
                        15,
                        "Lane",
                        "Townhouse",
                        "Mixed Use",
                        1200.00m,
                        1500.00m,
                        "Neglected garden area",
                        "Mid-terrace position",
                        "Street parking only",
                        DateTime.UtcNow.AddDays(-25),
                        "Previous tenant vacated",
                        "Month-to-month",
                        "Property requires significant renovation, ground floor previously used as retail space"
                    );
                }
            }

            // Add extra comprehensive examples with detailed specifications
            if (assets.Any(a => a.AssetNo.Contains("004")))
            {
                var detailedAsset = assets.First(a => a.AssetNo.Contains("004"));

                AddRatingCard(
                    detailedAsset,
                    "Concrete",
                    "Tile",
                    "Luxury",
                    "Good",
                    7,
                    "Road",
                    "Single Family",
                    "Residential",
                    2500.00m,
                    3200.00m,
                    "Extensive landscaped garden with mature trees and koi pond",
                    "Premium corner plot with 270-degree views",
                    "Triple garage with electric vehicle charging points",
                    DateTime.UtcNow.AddMonths(-2),
                    "High-profile tenant: Local celebrity",
                    "3-year fixed term lease with annual reviews",
                    "Executive property with high-end finishes, smart home technology throughout, security system, and dedicated home office space"
                );
            }

            // Add properties showing various conditions
            if (assets.Any(a => a.AssetNo.Contains("010")))
            {
                var conditionAsset = assets.First(a => a.AssetNo.Contains("010"));

                // Poor condition property
                AddRatingCard(
                    conditionAsset,
                    "Wood",
                    "Concrete",
                    "Basic",
                    "Poor",
                    25,
                    "Path",
                    "Single Family",
                    "Residential",
                    800.00m,
                    1000.00m,
                    "Overgrown garden with invasive species",
                    "Remote location with limited access",
                    "No designated parking",
                    DateTime.UtcNow.AddYears(-1),
                    "Vacant",
                    "Previously month-to-month",
                    "Property requires complete renovation. Structural issues evident. Damp problems throughout."
                );
            }

            // Add more comprehensive examples to showcase different property types

            // Add luxury penthouse
            if (assets.Any(a => a.AssetNo.Contains("011")))
            {
                var luxuryAsset = assets.First(a => a.AssetNo.Contains("011"));

                AddRatingCard(
                    luxuryAsset,
                    "Concrete",
                    "Wood",
                    "Luxury",
                    "Good",
                    3,
                    "Road",
                    "Apartment",
                    "Residential",
                    5000.00m,
                    6200.00m,
                    "Rooftop garden with exotic plants and irrigation system",
                    "Penthouse with 360-degree views",
                    "Secure underground parking with 3 allocated spaces and EV charging",
                    DateTime.UtcNow.AddDays(-5),
                    "High-net-worth professional",
                    "2-year lease with 6 months paid in advance",
                    "Premium property with concierge service, private elevator, home automation system, and designer fittings throughout. Swimming pool access and gym membership included."
                );
            }

            // Add heritage property with unique features
            if (assets.Any(a => a.AssetNo.Contains("009")))
            {
                var heritageAsset = assets.First(a => a.AssetNo.Contains("009"));

                AddRatingCard(
                    heritageAsset,
                    "Brick",
                    "Wood",
                    "Modern",
                    "Good",
                    120,
                    "Lane",
                    "Single Family",
                    "Residential",
                    3200.00m,
                    4000.00m,
                    "Heritage garden with protected ancient trees",
                    "Grade II listed building with conservation restrictions",
                    "Carriage house converted to garage for 2 vehicles",
                    DateTime.UtcNow.AddMonths(-6),
                    "Mr. & Mrs. Thompson (long-term tenants)",
                    "Protected tenancy with heritage maintenance obligations",
                    "Property has significant historical value with original features including cornicing, fireplace, and oak staircase. Refurbished to modern standards while preserving character. Energy efficiency rating affected by conservation restrictions."
                );
            }

            // Add mixed-use commercial/residential property
            if (assets.Any(a => a.AssetNo.Contains("007")))
            {
                var mixedUseAsset = assets.First(a => a.AssetNo.Contains("007"));

                AddRatingCard(
                    mixedUseAsset,
                    "Concrete",
                    "Tile",
                    "Modern",
                    "Good",
                    15,
                    "Road",
                    "Townhouse",
                    "Mixed Use",
                    4500.00m,
                    5200.00m,
                    "Small courtyard garden with seating area",
                    "Town center location with high foot traffic",
                    "Loading bay and staff parking for 2 vehicles",
                    DateTime.UtcNow.AddMonths(-1),
                    "Coastal Designs Ltd (retail) / Manager's accommodation above",
                    "Commercial lease with living accommodation clause",
                    "Ground floor used as retail space with separate entrance to first and second floor residential accommodation. Recently rewired and replumbed throughout. Includes enhanced security system and soundproofing between commercial and residential spaces."
                );
            }

            // Add property with fair condition requiring some work
            if (assets.Any(a => a.AssetNo.Contains("005")))
            {
                var improvementAsset = assets.First(a => a.AssetNo.Contains("005"));

                AddRatingCard(
                    improvementAsset,
                    "Brick",
                    "Wood",
                    "Basic",
                    "Fair",
                    45,
                    "Road",
                    "Single Family",
                    "Residential",
                    1200.00m,
                    1600.00m,
                    "Overgrown garden with potential for improvement",
                    "Semi-detached with no recent updates",
                    "Driveway parking for one vehicle, needs resurfacing",
                    DateTime.UtcNow.AddMonths(-3),
                    "Tenant recently vacated",
                    "Available for new tenancy",
                    "Property requires moderate renovation. Kitchen and bathrooms dated but functional. Evidence of minor damp in utility room. Heating system 20+ years old. Good structural integrity but cosmetic updates needed throughout."
                );

                // Add second rating card for same property with improvement suggestions
                AddRatingCard(
                    improvementAsset,
                    "Brick",
                    "Wood",
                    "Modern",
                    "Good",
                    45,
                    "Road",
                    "Single Family",
                    "Residential",
                    2000.00m,
                    2400.00m,
                    "Landscaped garden with new patio area",
                    "Semi-detached with full renovation",
                    "Newly resurfaced driveway with charging point",
                    DateTime.UtcNow.AddMonths(-1),
                    "Vacant - ready for occupancy",
                    "Available for new tenancy after improvements",
                    "Potential valuation after recommended improvements: New kitchen and bathrooms, resolving damp issues, new energy-efficient heating system, double glazing throughout, and modern decor would significantly increase rental value and energy rating."
                );
            }

            // Add student accommodation property
            if (assets.Any(a => a.AssetNo.Contains("003")))
            {
                var studentAsset = assets.First(a => a.AssetNo.Contains("003"));

                AddRatingCard(
                    studentAsset,
                    "Brick",
                    "Tile",
                    "Basic",
                    "Fair",
                    60,
                    "Road",
                    "Single Family",
                    "Residential",
                    3600.00m,
                    4000.00m,
                    "Low maintenance paved garden",
                    "HMO licensed property near university",
                    "On-street parking with permits available",
                    DateTime.UtcNow.AddMonths(-9),
                    "6 student occupants",
                    "Fixed term for academic year",
                    "Property converted for student letting with 6 bedrooms, 2 bathrooms, large communal kitchen/living area. All bedrooms furnished. Includes high-speed fiber broadband, fire alarm system, and weekly cleaning of communal areas. HMO license current for 3 more years."
                );
            }

            // Add accessible property with disability adaptations
            if (assets.Any(a => a.AssetNo.Contains("001")))
            {
                var accessibleAsset = assets.First(a => a.AssetNo.Contains("001"));

                AddRatingCard(
                    accessibleAsset,
                    "Brick",
                    "Tile",
                    "Modern",
                    "Good",
                    10,
                    "Road",
                    "Single Family",
                    "Residential",
                    1800.00m,
                    2200.00m,
                    "Level access garden with raised beds",
                    "Single-level bungalow with accessibility features",
                    "Wide driveway with disabled parking bay",
                    DateTime.UtcNow.AddMonths(-4),
                    "Tenant with mobility requirements",
                    "Long-term tenancy with council involvement",
                    "Property specially adapted with wheelchair access throughout, wet room with hoists, widened doorways, accessible kitchen with adjustable counters, and remote-controlled entry system. Additional adaptations may qualify for council grants."
                );
            }

            context.DomesticRatingCards.AddRange(ratingCards);
            context.SaveChanges();
            Console.WriteLine(
                "Domestic rating cards seeded successfully: "
                    + ratingCards.Count
                    + " records created."
            );
        }
    }
}
