using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using ValuationBackend.Models.iteration2.DTOs;
using ValuationBackend.Models.iteration2.RatingCards;
using ValuationBackend.Repositories;
using ValuationBackend.Repositories.iteration2;

namespace ValuationBackend.Services.iteration2
{
    public class OfficesRatingCardService : IOfficesRatingCardService
    {
        private readonly IOfficesRatingCardRepository _repository;
        private readonly IAssetRepository _assetRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OfficesRatingCardService(
            IOfficesRatingCardRepository repository,
            IAssetRepository assetRepository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _assetRepository = assetRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<OfficesRatingCardDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<OfficesRatingCardDto>>(entities);
        }

        public async Task<OfficesRatingCardDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"OfficesRatingCard with ID {id} not found.");
            
            return _mapper.Map<OfficesRatingCardDto>(entity);
        }

        public async Task<OfficesRatingCardDto> GetByAssetIdAsync(int assetId)
        {
            var entity = await _repository.GetByAssetIdAsync(assetId);
            if (entity == null)
                throw new KeyNotFoundException($"OfficesRatingCard for Asset ID {assetId} not found.");
            
            return _mapper.Map<OfficesRatingCardDto>(entity);
        }

        public async Task<OfficesRatingCardDto> CreateAsync(CreateOfficesRatingCardDto dto)
        {
            // Check if rating card already exists for this asset
            if (await _repository.ExistsByAssetIdAsync(dto.AssetId))
            {
                throw new InvalidOperationException($"OfficesRatingCard already exists for Asset ID {dto.AssetId}.");
            }

            // Get asset details for auto-generation
            var asset = _assetRepository.GetById(dto.AssetId);
            if (asset == null)
            {
                throw new KeyNotFoundException($"Asset with ID {dto.AssetId} not found.");
            }

            var entity = _mapper.Map<OfficesRatingCard>(dto);
            
            // Auto-generate fields from asset if not provided
            if (string.IsNullOrWhiteSpace(entity.NewNumber))
                entity.NewNumber = asset.AssetNo;
            
            if (string.IsNullOrWhiteSpace(entity.Owner))
                entity.Owner = asset.Owner;
            
            if (string.IsNullOrWhiteSpace(entity.Description))
                entity.Description = asset.Description.ToString();

            // Convert Date to UTC if it's not null
            if (entity.Date.HasValue && entity.Date.Value.Kind != DateTimeKind.Utc)
            {
                entity.Date = DateTime.SpecifyKind(entity.Date.Value, DateTimeKind.Utc);
            }

            // Set audit fields
            entity.CreatedBy = GetCurrentUser();
            entity.CreatedAt = DateTime.UtcNow;

            var created = await _repository.CreateAsync(entity);
            
            // Update the asset's IsRatingCard flag to true
            asset.IsRatingCard = true;
            _assetRepository.Update(asset);
            
            return _mapper.Map<OfficesRatingCardDto>(created);
        }

        public async Task<OfficesRatingCardDto> UpdateAsync(int id, UpdateOfficesRatingCardDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"OfficesRatingCard with ID {id} not found.");

            _mapper.Map(dto, entity);
            
            // Set audit fields
            entity.UpdatedBy = GetCurrentUser();
            entity.UpdatedAt = DateTime.UtcNow;

            var updated = await _repository.UpdateAsync(entity);
            return _mapper.Map<OfficesRatingCardDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // Get the rating card to find the associated asset
            var ratingCard = await _repository.GetByIdAsync(id);
            if (ratingCard == null)
                return false;
            
            // Delete the rating card
            var result = await _repository.DeleteAsync(id);
            
            if (result)
            {
                // Update the asset's IsRatingCard flag to false
                var asset = _assetRepository.GetById(ratingCard.AssetId);
                if (asset != null)
                {
                    asset.IsRatingCard = false;
                    _assetRepository.Update(asset);
                }
            }
            
            return result;
        }

        public async Task<OfficesRatingCardAutofillDto> GetAutofillDataAsync(int assetId)
        {
            var asset = _assetRepository.GetById(assetId);
            if (asset == null)
            {
                throw new KeyNotFoundException($"Asset with ID {assetId} not found.");
            }

            return new OfficesRatingCardAutofillDto
            {
                NewNumber = asset.AssetNo,
                Owner = asset.Owner,
                Description = asset.Description.ToString()
            };
        }

        private string GetCurrentUser()
        {
            return _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "System";
        }
    }
}