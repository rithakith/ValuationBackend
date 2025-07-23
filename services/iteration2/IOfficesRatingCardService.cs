using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Services
{
    public interface IOfficesRatingCardService
    {
        /// <summary>
        /// Get all offices rating cards
        /// </summary>
        Task<List<OfficesRatingCard>> GetAllAsync();
        
        /// <summary>
        /// Get offices rating card by id
        /// </summary>
        Task<OfficesRatingCard> GetByIdAsync(int id);
        
        /// <summary>
        /// Get offices rating cards by asset id
        /// </summary>
        Task<List<OfficesRatingCard>> GetByAssetIdAsync(int assetId);
        
        /// <summary>
        /// Create a new offices rating card
        /// </summary>
        Task<OfficesRatingCard> CreateAsync(OfficesRatingCard officesRatingCard);
        
        /// <summary>
        /// Update an existing offices rating card
        /// </summary>
        Task<OfficesRatingCard> UpdateAsync(OfficesRatingCard officesRatingCard);
        
        /// <summary>
        /// Delete an offices rating card
        /// </summary>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Get asset by id for autofill functionality
        /// </summary>
        Task<Asset?> GetAssetByIdAsync(int assetId);

        /// <summary>
        /// Generate new number for offices rating card
        /// </summary>
        Task<string> GenerateNewNumberAsync(int assetId);
    }
}