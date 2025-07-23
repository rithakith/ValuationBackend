using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.iteration2.DTOs;

namespace ValuationBackend.Services.iteration2
{
    public interface IOfficesRatingCardService
    {
        Task<IEnumerable<OfficesRatingCardDto>> GetAllAsync();
        Task<OfficesRatingCardDto> GetByIdAsync(int id);
        Task<OfficesRatingCardDto> GetByAssetIdAsync(int assetId);
        Task<OfficesRatingCardDto> CreateAsync(CreateOfficesRatingCardDto dto);
        Task<OfficesRatingCardDto> UpdateAsync(int id, UpdateOfficesRatingCardDto dto);
        Task<bool> DeleteAsync(int id);
        Task<OfficesRatingCardAutofillDto> GetAutofillDataAsync(int assetId);
    }
}