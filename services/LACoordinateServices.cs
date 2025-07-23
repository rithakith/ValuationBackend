using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    // PastValuationsLA Coordinate Service
    public class PastValuationsLACoordinateService : IPastValuationsLACoordinateService
    {
        private readonly IPastValuationsLACoordinateRepository _repository;
        private readonly IMapper _mapper;

        public PastValuationsLACoordinateService(IPastValuationsLACoordinateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PastValuationsLACoordinateResponseDto>> GetAllAsync()
        {
            var coordinates = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PastValuationsLACoordinateResponseDto>>(coordinates);
        }

        public async Task<PastValuationsLACoordinateResponseDto> GetByIdAsync(int id)
        {
            var coordinate = await _repository.GetByIdAsync(id);
            if (coordinate == null)
            {
                return null;
            }

            return _mapper.Map<PastValuationsLACoordinateResponseDto>(coordinate);
        }

        public async Task<IEnumerable<PastValuationsLACoordinateResponseDto>> GetByPastValuationIdAsync(int pastValuationId)
        {
            var coordinates = await _repository.GetByPastValuationIdAsync(pastValuationId);
            return _mapper.Map<IEnumerable<PastValuationsLACoordinateResponseDto>>(coordinates);
        }

        public async Task<PastValuationsLACoordinateResponseDto> CreateAsync(PastValuationsLACoordinateCreateDto dto)
        {
            var masterFileExists = await _repository.MasterFileExistsAsync(dto.MasterfileId);
            if (!masterFileExists)
            {
                throw new ArgumentException($"Masterfile with ID {dto.MasterfileId} does not exist.");
            }

            var coordinate = _mapper.Map<PastValuationsLACoordinate>(dto);
            // Set PastValuationId to null since it will be assigned later
            coordinate.PastValuationId = null;
            var createdCoordinate = await _repository.CreateAsync(coordinate);
            return _mapper.Map<PastValuationsLACoordinateResponseDto>(createdCoordinate);
        }

        public async Task<PastValuationsLACoordinateResponseDto> UpdateAsync(int id, PastValuationsLACoordinateUpdateDto dto)
        {
            var existingCoordinate = await _repository.GetByIdAsync(id);
            if (existingCoordinate == null)
            {
                return null;
            }

            var pastValuationExists = await _repository.PastValuationExistsAsync(dto.PastValuationId);
            if (!pastValuationExists)
            {
                throw new ArgumentException($"PastValuation with ID {dto.PastValuationId} does not exist.");
            }

            var masterFileExists = await _repository.MasterFileExistsAsync(dto.MasterfileId);
            if (!masterFileExists)
            {
                throw new ArgumentException($"Masterfile with ID {dto.MasterfileId} does not exist.");
            }

            _mapper.Map(dto, existingCoordinate);
            
            var updateSuccess = await _repository.UpdateAsync(existingCoordinate);
            if (!updateSuccess)
            {
                throw new InvalidOperationException("Failed to update coordinate.");
            }

            var updatedCoordinate = await _repository.GetByIdAsync(id);
            return _mapper.Map<PastValuationsLACoordinateResponseDto>(updatedCoordinate);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }

    // BuildingRatesLA Coordinate Service
    public class BuildingRatesLACoordinateService : IBuildingRatesLACoordinateService
    {
        private readonly IBuildingRatesLACoordinateRepository _repository;
        private readonly IMapper _mapper;

        public BuildingRatesLACoordinateService(IBuildingRatesLACoordinateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BuildingRatesLACoordinateResponseDto>> GetAllAsync()
        {
            var coordinates = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<BuildingRatesLACoordinateResponseDto>>(coordinates);
        }

        public async Task<BuildingRatesLACoordinateResponseDto> GetByIdAsync(int id)
        {
            var coordinate = await _repository.GetByIdAsync(id);
            if (coordinate == null)
            {
                return null;
            }

            return _mapper.Map<BuildingRatesLACoordinateResponseDto>(coordinate);
        }

        public async Task<IEnumerable<BuildingRatesLACoordinateResponseDto>> GetByBuildingRateIdAsync(int buildingRateId)
        {
            var coordinates = await _repository.GetByBuildingRateIdAsync(buildingRateId);
            return _mapper.Map<IEnumerable<BuildingRatesLACoordinateResponseDto>>(coordinates);
        }

        public async Task<BuildingRatesLACoordinateResponseDto> CreateAsync(BuildingRatesLACoordinateCreateDto dto)
        {
            var masterFileExists = await _repository.MasterFileExistsAsync(dto.MasterfileId);
            if (!masterFileExists)
            {
                throw new ArgumentException($"Masterfile with ID {dto.MasterfileId} does not exist.");
            }

            var coordinate = _mapper.Map<BuildingRatesLACoordinate>(dto);
            // Set BuildingRateId to null since it will be assigned later
            coordinate.BuildingRateId = null;
            var createdCoordinate = await _repository.CreateAsync(coordinate);
            return _mapper.Map<BuildingRatesLACoordinateResponseDto>(createdCoordinate);
        }

        public async Task<BuildingRatesLACoordinateResponseDto> UpdateAsync(int id, BuildingRatesLACoordinateUpdateDto dto)
        {
            var existingCoordinate = await _repository.GetByIdAsync(id);
            if (existingCoordinate == null)
            {
                return null;
            }

            var buildingRateExists = await _repository.BuildingRateExistsAsync(dto.BuildingRateId);
            if (!buildingRateExists)
            {
                throw new ArgumentException($"BuildingRate with ID {dto.BuildingRateId} does not exist.");
            }

            var masterFileExists = await _repository.MasterFileExistsAsync(dto.MasterfileId);
            if (!masterFileExists)
            {
                throw new ArgumentException($"Masterfile with ID {dto.MasterfileId} does not exist.");
            }

            _mapper.Map(dto, existingCoordinate);
            
            var updateSuccess = await _repository.UpdateAsync(existingCoordinate);
            if (!updateSuccess)
            {
                throw new InvalidOperationException("Failed to update coordinate.");
            }

            var updatedCoordinate = await _repository.GetByIdAsync(id);
            return _mapper.Map<BuildingRatesLACoordinateResponseDto>(updatedCoordinate);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }

    // SalesEvidenceLA Coordinate Service
    public class SalesEvidenceLACoordinateService : ISalesEvidenceLACoordinateService
    {
        private readonly ISalesEvidenceLACoordinateRepository _repository;
        private readonly IMapper _mapper;

        public SalesEvidenceLACoordinateService(ISalesEvidenceLACoordinateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SalesEvidenceLACoordinateResponseDto>> GetAllAsync()
        {
            var coordinates = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<SalesEvidenceLACoordinateResponseDto>>(coordinates);
        }

        public async Task<SalesEvidenceLACoordinateResponseDto> GetByIdAsync(int id)
        {
            var coordinate = await _repository.GetByIdAsync(id);
            if (coordinate == null)
            {
                return null;
            }

            return _mapper.Map<SalesEvidenceLACoordinateResponseDto>(coordinate);
        }

        public async Task<IEnumerable<SalesEvidenceLACoordinateResponseDto>> GetBySalesEvidenceIdAsync(int salesEvidenceId)
        {
            var coordinates = await _repository.GetBySalesEvidenceIdAsync(salesEvidenceId);
            return _mapper.Map<IEnumerable<SalesEvidenceLACoordinateResponseDto>>(coordinates);
        }

        public async Task<SalesEvidenceLACoordinateResponseDto> CreateAsync(SalesEvidenceLACoordinateCreateDto dto)
        {
            var masterFileExists = await _repository.MasterFileExistsAsync(dto.MasterfileId);
            if (!masterFileExists)
            {
                throw new ArgumentException($"Masterfile with ID {dto.MasterfileId} does not exist.");
            }

            var coordinate = _mapper.Map<SalesEvidenceLACoordinate>(dto);
            // Set SalesEvidenceId to null since it will be assigned later
            coordinate.SalesEvidenceId = null;
            var createdCoordinate = await _repository.CreateAsync(coordinate);
            return _mapper.Map<SalesEvidenceLACoordinateResponseDto>(createdCoordinate);
        }

        public async Task<SalesEvidenceLACoordinateResponseDto> UpdateAsync(int id, SalesEvidenceLACoordinateUpdateDto dto)
        {
            var existingCoordinate = await _repository.GetByIdAsync(id);
            if (existingCoordinate == null)
            {
                return null;
            }

            var salesEvidenceExists = await _repository.SalesEvidenceExistsAsync(dto.SalesEvidenceId);
            if (!salesEvidenceExists)
            {
                throw new ArgumentException($"SalesEvidence with ID {dto.SalesEvidenceId} does not exist.");
            }

            var masterFileExists = await _repository.MasterFileExistsAsync(dto.MasterfileId);
            if (!masterFileExists)
            {
                throw new ArgumentException($"Masterfile with ID {dto.MasterfileId} does not exist.");
            }

            _mapper.Map(dto, existingCoordinate);
            
            var updateSuccess = await _repository.UpdateAsync(existingCoordinate);
            if (!updateSuccess)
            {
                throw new InvalidOperationException("Failed to update coordinate.");
            }

            var updatedCoordinate = await _repository.GetByIdAsync(id);
            return _mapper.Map<SalesEvidenceLACoordinateResponseDto>(updatedCoordinate);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }

    // RentalEvidenceLA Coordinate Service
    public class RentalEvidenceLACoordinateService : IRentalEvidenceLACoordinateService
    {
        private readonly IRentalEvidenceLACoordinateRepository _repository;
        private readonly IMapper _mapper;

        public RentalEvidenceLACoordinateService(IRentalEvidenceLACoordinateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RentalEvidenceLACoordinateResponseDto>> GetAllAsync()
        {
            var coordinates = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<RentalEvidenceLACoordinateResponseDto>>(coordinates);
        }

        public async Task<RentalEvidenceLACoordinateResponseDto> GetByIdAsync(int id)
        {
            var coordinate = await _repository.GetByIdAsync(id);
            if (coordinate == null)
            {
                return null;
            }

            return _mapper.Map<RentalEvidenceLACoordinateResponseDto>(coordinate);
        }

        public async Task<IEnumerable<RentalEvidenceLACoordinateResponseDto>> GetByRentalEvidenceIdAsync(int rentalEvidenceId)
        {
            var coordinates = await _repository.GetByRentalEvidenceIdAsync(rentalEvidenceId);
            return _mapper.Map<IEnumerable<RentalEvidenceLACoordinateResponseDto>>(coordinates);
        }

        public async Task<RentalEvidenceLACoordinateResponseDto> CreateAsync(RentalEvidenceLACoordinateCreateDto dto)
        {
            var masterFileExists = await _repository.MasterFileExistsAsync(dto.MasterfileId);
            if (!masterFileExists)
            {
                throw new ArgumentException($"Masterfile with ID {dto.MasterfileId} does not exist.");
            }

            var coordinate = _mapper.Map<RentalEvidenceLACoordinate>(dto);
            // Set RentalEvidenceId to null since it will be assigned later
            coordinate.RentalEvidenceId = null;
            var createdCoordinate = await _repository.CreateAsync(coordinate);
            return _mapper.Map<RentalEvidenceLACoordinateResponseDto>(createdCoordinate);
        }

        public async Task<RentalEvidenceLACoordinateResponseDto> UpdateAsync(int id, RentalEvidenceLACoordinateUpdateDto dto)
        {
            var existingCoordinate = await _repository.GetByIdAsync(id);
            if (existingCoordinate == null)
            {
                return null;
            }

            var rentalEvidenceExists = await _repository.RentalEvidenceExistsAsync(dto.RentalEvidenceId);
            if (!rentalEvidenceExists)
            {
                throw new ArgumentException($"RentalEvidence with ID {dto.RentalEvidenceId} does not exist.");
            }

            var masterFileExists = await _repository.MasterFileExistsAsync(dto.MasterfileId);
            if (!masterFileExists)
            {
                throw new ArgumentException($"Masterfile with ID {dto.MasterfileId} does not exist.");
            }

            _mapper.Map(dto, existingCoordinate);
            
            var updateSuccess = await _repository.UpdateAsync(existingCoordinate);
            if (!updateSuccess)
            {
                throw new InvalidOperationException("Failed to update coordinate.");
            }

            var updatedCoordinate = await _repository.GetByIdAsync(id);
            return _mapper.Map<RentalEvidenceLACoordinateResponseDto>(updatedCoordinate);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
