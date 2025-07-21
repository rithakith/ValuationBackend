using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.iteration2.RatingCards;

namespace ValuationBackend.repositories.iteration2
{
    public interface IOfficesRatingCardRepository
    {
        Task<IEnumerable<OfficesRatingCard>> GetAllAsync();
        Task<OfficesRatingCard> GetByIdAsync(int id);
        Task<OfficesRatingCard> GetByAssetIdAsync(int assetId);
        Task<OfficesRatingCard> CreateAsync(OfficesRatingCard officesRatingCard);
        Task<OfficesRatingCard> UpdateAsync(OfficesRatingCard officesRatingCard);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsByAssetIdAsync(int assetId);
    }
}