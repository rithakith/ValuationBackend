using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ValuationBackend.DTOs.iteration2;
using ValuationBackend.Models.iteration2;
using ValuationBackend.Repositories.iteration2;

namespace ValuationBackend.Services.iteration2
{
    public interface II2RentalEvidenceService
    {
        Task<I2RentalEvidenceDto> GetByIdAsync(int id);
        Task<IEnumerable<I2RentalEvidenceDto>> GetByAssetIdAsync(int assetId);
        Task<IEnumerable<I2RentalEvidenceDto>> GetAllAsync();
        Task<I2RentalEvidenceDto> CreateAsync(CreateI2RentalEvidenceDto dto, string userId);
        Task<I2RentalEvidenceDto> UpdateAsync(int id, UpdateI2RentalEvidenceDto dto, string userId);
        Task<bool> DeleteAsync(int id);
    }

    public class I2RentalEvidenceService : II2RentalEvidenceService
    {
        private readonly II2RentalEvidenceRepository _repository;
        private readonly IMapper _mapper;

        public I2RentalEvidenceService(II2RentalEvidenceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<I2RentalEvidenceDto> GetByIdAsync(int id)
        {
            var rentalEvidence = await _repository.GetByIdAsync(id);
            if (rentalEvidence == null)
                throw new KeyNotFoundException($"I2RentalEvidence with ID {id} not found.");
            
            return _mapper.Map<I2RentalEvidenceDto>(rentalEvidence);
        }

        public async Task<IEnumerable<I2RentalEvidenceDto>> GetByAssetIdAsync(int assetId)
        {
            var rentalEvidences = await _repository.GetByAssetIdAsync(assetId);
            return _mapper.Map<IEnumerable<I2RentalEvidenceDto>>(rentalEvidences);
        }

        public async Task<IEnumerable<I2RentalEvidenceDto>> GetAllAsync()
        {
            var rentalEvidences = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<I2RentalEvidenceDto>>(rentalEvidences);
        }

        public async Task<I2RentalEvidenceDto> CreateAsync(CreateI2RentalEvidenceDto dto, string userId)
        {
            var rentalEvidence = _mapper.Map<I2RentalEvidence>(dto);
            rentalEvidence.CreatedBy = userId;
            rentalEvidence.CreatedAt = DateTime.UtcNow;

            // If AssetId is 0 or 1, try to find any existing asset or create a dummy one
            if (dto.AssetId <= 1)
            {
                // Try to get any existing asset from the database
                var anyAsset = await _repository.GetAnyAssetIdAsync();
                if (anyAsset.HasValue)
                {
                    rentalEvidence.AssetId = anyAsset.Value;
                }
                else
                {
                    // Create a dummy asset if none exists
                    var dummyAssetId = await _repository.CreateDummyAssetAsync();
                    rentalEvidence.AssetId = dummyAssetId;
                }
            }

            var created = await _repository.CreateAsync(rentalEvidence);
            return _mapper.Map<I2RentalEvidenceDto>(created);
        }

        public async Task<I2RentalEvidenceDto> UpdateAsync(int id, UpdateI2RentalEvidenceDto dto, string userId)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"I2RentalEvidence with ID {id} not found.");

            _mapper.Map(dto, existing);
            existing.UpdatedBy = userId;
            existing.UpdatedAt = DateTime.UtcNow;

            var updated = await _repository.UpdateAsync(existing);
            return _mapper.Map<I2RentalEvidenceDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}