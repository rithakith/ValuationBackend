using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class OfficesRatingCardService : IOfficesRatingCardService
    {
        private readonly IOfficesRatingCardRepository _repository;
        private readonly IAssetService _assetService;

        public OfficesRatingCardService(IOfficesRatingCardRepository repository, IAssetService assetService)
        {
            _repository = repository;
            _assetService = assetService;
        }

        public async Task<List<OfficesRatingCard>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<OfficesRatingCard> GetByIdAsync(int id)
        {
            var card = await _repository.GetByIdAsync(id);
            
            if (card == null)
            {
                throw new Exception($"Offices Rating Card with ID {id} not found.");
            }
            
            return card;
        }

        public async Task<List<OfficesRatingCard>> GetByAssetIdAsync(int assetId)
        {
            return await _repository.GetByAssetIdAsync(assetId);
        }

        public async Task<OfficesRatingCard> CreateAsync(OfficesRatingCard officesRatingCard)
        {
            // Validate required fields
            ValidateOfficesRatingCard(officesRatingCard);
            
            // Create the rating card
            var createdRatingCard = await _repository.CreateAsync(officesRatingCard);
            
            // Update the associated Asset's IsRatingCard property to true
            var asset = _assetService.GetAssetById(officesRatingCard.AssetId);
            if (asset != null && !asset.IsRatingCard)
            {
                asset.IsRatingCard = true;
                _assetService.UpdateAsset(asset);
            }
            
            return createdRatingCard;
        }

        public async Task<OfficesRatingCard> UpdateAsync(OfficesRatingCard officesRatingCard)
        {
            // Validate required fields
            ValidateOfficesRatingCard(officesRatingCard);
            
            return await _repository.UpdateAsync(officesRatingCard);
        }

        public async Task<bool> DeleteAsync(int id)
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

        private void ValidateOfficesRatingCard(OfficesRatingCard officesRatingCard)
        {
            // Check if AssetId is valid
            if (officesRatingCard.AssetId <= 0)
            {
                throw new ArgumentException("Asset ID must be greater than 0.");
            }
            
            // Validate numeric fields if they have values
            if (officesRatingCard.Age.HasValue && officesRatingCard.Age < 0)
            {
                throw new ArgumentException("Age cannot be negative.");
            }
            
            if (officesRatingCard.WardNumber.HasValue && officesRatingCard.WardNumber < 0)
            {
                throw new ArgumentException("Ward number cannot be negative.");
            }
            
            if (officesRatingCard.FloorNumber.HasValue && officesRatingCard.FloorNumber < -10)
            {
                throw new ArgumentException("Floor number cannot be less than -10.");
            }
            
            if (officesRatingCard.CeilingHeight.HasValue && officesRatingCard.CeilingHeight <= 0)
            {
                throw new ArgumentException("Ceiling height must be greater than 0.");
            }
            
            if (officesRatingCard.TotalArea.HasValue && officesRatingCard.TotalArea <= 0)
            {
                throw new ArgumentException("Total area must be greater than 0.");
            }
            
            if (officesRatingCard.UsableFloorArea.HasValue && officesRatingCard.UsableFloorArea <= 0)
            {
                throw new ArgumentException("Usable floor area must be greater than 0.");
            }
            
            if (officesRatingCard.RentPM.HasValue && officesRatingCard.RentPM < 0)
            {
                throw new ArgumentException("Rent per month cannot be negative.");
            }
            
            if (officesRatingCard.SuggestedRate.HasValue && officesRatingCard.SuggestedRate < 0)
            {
                throw new ArgumentException("Suggested rate cannot be negative.");
            }
        }
    }
}