using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class LALotService : ILALotService
    {
        private readonly ILALotRepository _laLotRepository;
        private readonly IMapper _mapper;

        public LALotService(ILALotRepository laLotRepository, IMapper mapper)
        {
            _laLotRepository = laLotRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LALotResponseDto>> GetAllAsync()
        {
            var laLots = await _laLotRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<LALotResponseDto>>(laLots);
        }

        public async Task<LALotResponseDto> GetByIdAsync(int id)
        {
            var laLot = await _laLotRepository.GetByIdAsync(id);
            if (laLot == null)
            {
                return null;
            }

            return _mapper.Map<LALotResponseDto>(laLot);
        }

        public async Task<IEnumerable<LALotResponseDto>> GetByMasterFileIdAsync(int masterFileId)
        {
            var laLots = await _laLotRepository.GetByMasterFileIdAsync(masterFileId);
            return _mapper.Map<IEnumerable<LALotResponseDto>>(laLots);
        }

        public async Task<LALotResponseDto> CreateAsync(LALotCreateDto dto)
        {
            // Validate that the MasterFile exists
            var masterFileExists = await _laLotRepository.MasterFileExistsAsync(dto.MasterFileId);
            if (!masterFileExists)
            {
                throw new ArgumentException($"MasterFile with ID {dto.MasterFileId} does not exist.");
            }

            var laLot = _mapper.Map<LALot>(dto);
            var createdLaLot = await _laLotRepository.CreateAsync(laLot);
            return _mapper.Map<LALotResponseDto>(createdLaLot);
        }

        public async Task<LALotResponseDto> UpdateAsync(int id, LALotUpdateDto dto)
        {
            var existingLaLot = await _laLotRepository.GetByIdAsync(id);
            if (existingLaLot == null)
            {
                return null;
            }

            // Validate that the MasterFile exists
            var masterFileExists = await _laLotRepository.MasterFileExistsAsync(dto.MasterFileId);
            if (!masterFileExists)
            {
                throw new ArgumentException($"MasterFile with ID {dto.MasterFileId} does not exist.");
            }

            _mapper.Map(dto, existingLaLot);
            
            var updateSuccess = await _laLotRepository.UpdateAsync(existingLaLot);
            if (!updateSuccess)
            {
                throw new InvalidOperationException("Failed to update LALot.");
            }

            var updatedLaLot = await _laLotRepository.GetByIdAsync(id);
            return _mapper.Map<LALotResponseDto>(updatedLaLot);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _laLotRepository.DeleteAsync(id);
        }
    }
}
