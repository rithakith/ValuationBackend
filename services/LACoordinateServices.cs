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

        public async Task<IEnumerable<PastValuationsLACoordinateResponseDto>> GetByReportIdAsync(int reportId)
        {
            var coordinates = await _repository.GetByReportIdAsync(reportId);
            return _mapper.Map<IEnumerable<PastValuationsLACoordinateResponseDto>>(coordinates);
        }

        public async Task<PastValuationsLACoordinateResponseDto> CreateAsync(PastValuationsLACoordinateCreateDto dto)
        {
            var reportExists = await _repository.ReportExistsAsync(dto.ReportId);
            if (!reportExists)
            {
                throw new ArgumentException($"Report with ID {dto.ReportId} does not exist.");
            }

            var coordinate = _mapper.Map<PastValuationsLACoordinate>(dto);
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

            var reportExists = await _repository.ReportExistsAsync(dto.ReportId);
            if (!reportExists)
            {
                throw new ArgumentException($"Report with ID {dto.ReportId} does not exist.");
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

        public async Task<IEnumerable<BuildingRatesLACoordinateResponseDto>> GetByReportIdAsync(int reportId)
        {
            var coordinates = await _repository.GetByReportIdAsync(reportId);
            return _mapper.Map<IEnumerable<BuildingRatesLACoordinateResponseDto>>(coordinates);
        }

        public async Task<BuildingRatesLACoordinateResponseDto> CreateAsync(BuildingRatesLACoordinateCreateDto dto)
        {
            var reportExists = await _repository.ReportExistsAsync(dto.ReportId);
            if (!reportExists)
            {
                throw new ArgumentException($"Report with ID {dto.ReportId} does not exist.");
            }

            var coordinate = _mapper.Map<BuildingRatesLACoordinate>(dto);
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

            var reportExists = await _repository.ReportExistsAsync(dto.ReportId);
            if (!reportExists)
            {
                throw new ArgumentException($"Report with ID {dto.ReportId} does not exist.");
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

        public async Task<IEnumerable<SalesEvidenceLACoordinateResponseDto>> GetByReportIdAsync(int reportId)
        {
            var coordinates = await _repository.GetByReportIdAsync(reportId);
            return _mapper.Map<IEnumerable<SalesEvidenceLACoordinateResponseDto>>(coordinates);
        }

        public async Task<SalesEvidenceLACoordinateResponseDto> CreateAsync(SalesEvidenceLACoordinateCreateDto dto)
        {
            var reportExists = await _repository.ReportExistsAsync(dto.ReportId);
            if (!reportExists)
            {
                throw new ArgumentException($"Report with ID {dto.ReportId} does not exist.");
            }

            var coordinate = _mapper.Map<SalesEvidenceLACoordinate>(dto);
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

            var reportExists = await _repository.ReportExistsAsync(dto.ReportId);
            if (!reportExists)
            {
                throw new ArgumentException($"Report with ID {dto.ReportId} does not exist.");
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

        public async Task<IEnumerable<RentalEvidenceLACoordinateResponseDto>> GetByReportIdAsync(int reportId)
        {
            var coordinates = await _repository.GetByReportIdAsync(reportId);
            return _mapper.Map<IEnumerable<RentalEvidenceLACoordinateResponseDto>>(coordinates);
        }

        public async Task<RentalEvidenceLACoordinateResponseDto> CreateAsync(RentalEvidenceLACoordinateCreateDto dto)
        {
            var reportExists = await _repository.ReportExistsAsync(dto.ReportId);
            if (!reportExists)
            {
                throw new ArgumentException($"Report with ID {dto.ReportId} does not exist.");
            }

            var coordinate = _mapper.Map<RentalEvidenceLACoordinate>(dto);
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

            var reportExists = await _repository.ReportExistsAsync(dto.ReportId);
            if (!reportExists)
            {
                throw new ArgumentException($"Report with ID {dto.ReportId} does not exist.");
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
