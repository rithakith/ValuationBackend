using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Models.Enums;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{    public class DomesticRatingCardService : IDomesticRatingCardService
    {
        private readonly IDomesticRatingCardRepository _repository;
        private readonly IAssetService _assetService;

        public DomesticRatingCardService(IDomesticRatingCardRepository repository, IAssetService assetService)
        {
            _repository = repository;
            _assetService = assetService;
        }

        public async Task<List<DomesticRatingCard>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<DomesticRatingCard> GetByIdAsync(int id)
        {
            var card = await _repository.GetByIdAsync(id);
            
            if (card == null)
            {
                throw new Exception($"Domestic Rating Card with ID {id} not found.");
            }
            
            return card;
        }

        public async Task<List<DomesticRatingCard>> GetByAssetIdAsync(int assetId)
        {
            return await _repository.GetByAssetIdAsync(assetId);
        }

        public async Task<DomesticRatingCard> CreateAsync(DomesticRatingCard domesticRatingCard)
        {
            // Validate required fields
            ValidateDomesticRatingCard(domesticRatingCard);
            
            return await _repository.CreateAsync(domesticRatingCard);
        }

        public async Task<DomesticRatingCard> UpdateAsync(DomesticRatingCard domesticRatingCard)
        {
            // Validate required fields
            ValidateDomesticRatingCard(domesticRatingCard);
            
            return await _repository.UpdateAsync(domesticRatingCard);
        }        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Asset?> GetAssetByIdAsync(int assetId)
        {
            return await Task.FromResult(_assetService.GetAssetById(assetId));
        }

        public async Task<string> GenerateNewNumberAsync(int assetId)
        {
            return await _repository.GenerateNewNumberAsync(assetId);
        }

        private void ValidateDomesticRatingCard(DomesticRatingCard domesticRatingCard)
        {
            // Check if AssetId is valid
            if (domesticRatingCard.AssetId <= 0)
            {
                throw new ArgumentException("Asset ID must be greater than 0.");
            }
            
            // No need to validate NewNumber, Owner, or Description as they are auto-filled
            
            // Validate required enum values
            if (!Enum.IsDefined(typeof(WallType), domesticRatingCard.SelectWalls))
            {
                throw new ArgumentException($"Invalid wall type specified: {domesticRatingCard.SelectWalls}");
            }
            
            if (!Enum.IsDefined(typeof(FloorType), domesticRatingCard.Floor))
            {
                throw new ArgumentException($"Invalid floor type specified: {domesticRatingCard.Floor}");
            }
            
            if (!Enum.IsDefined(typeof(ConvenienceType), domesticRatingCard.Conveniences))
            {
                throw new ArgumentException($"Invalid convenience type specified: {domesticRatingCard.Conveniences}");
            }
            
            if (!Enum.IsDefined(typeof(ConditionType), domesticRatingCard.Condition))
            {
                throw new ArgumentException($"Invalid condition type specified: {domesticRatingCard.Condition}");
            }
            
            if (!Enum.IsDefined(typeof(AccessType), domesticRatingCard.Access))
            {
                throw new ArgumentException($"Invalid access type specified: {domesticRatingCard.Access}");
            }
            
            if (!Enum.IsDefined(typeof(PropertySubCategory), domesticRatingCard.PropertySubCategory))
            {
                throw new ArgumentException($"Invalid property sub-category specified: {domesticRatingCard.PropertySubCategory}");
            }
            
            if (!Enum.IsDefined(typeof(ResidentialPropertyType), domesticRatingCard.PropertyType))
            {
                throw new ArgumentException($"Invalid property type specified: {domesticRatingCard.PropertyType}");
            }
            
            // Validate age (if provided)
            if (domesticRatingCard.Age.HasValue && domesticRatingCard.Age.Value < 0)
            {
                throw new ArgumentException("Age cannot be negative.");
            }
            
            // Validate monetary values (if provided)
            if (domesticRatingCard.RentPM.HasValue && domesticRatingCard.RentPM.Value < 0)
            {
                throw new ArgumentException("Monthly rent cannot be negative.");
            }
            
            if (domesticRatingCard.SuggestedRate.HasValue && domesticRatingCard.SuggestedRate.Value < 0)
            {
                throw new ArgumentException("Suggested rate cannot be negative.");
            }
            
            // Validate date is not in the future
            if (domesticRatingCard.Date.HasValue && domesticRatingCard.Date.Value > DateTime.Now)
            {
                throw new ArgumentException("Date cannot be in the future.");
            }
        }
    }
}
