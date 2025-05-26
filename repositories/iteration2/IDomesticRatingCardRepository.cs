using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;

namespace ValuationBackend.Repositories
{
    public interface IDomesticRatingCardRepository
    {
        /// <summary>
        /// Get all domestic rating cards
        /// </summary>
        Task<List<DomesticRatingCard>> GetAllAsync();
        
        /// <summary>
        /// Get domestic rating card by id
        /// </summary>
        Task<DomesticRatingCard> GetByIdAsync(int id);
        
        /// <summary>
        /// Get domestic rating cards by asset id
        /// </summary>
        Task<List<DomesticRatingCard>> GetByAssetIdAsync(int assetId);
        
        /// <summary>
        /// Create a new domestic rating card
        /// </summary>
        Task<DomesticRatingCard> CreateAsync(DomesticRatingCard domesticRatingCard);
        
        /// <summary>
        /// Update an existing domestic rating card
        /// </summary>
        Task<DomesticRatingCard> UpdateAsync(DomesticRatingCard domesticRatingCard);
        
        /// <summary>
        /// Delete a domestic rating card
        /// </summary>
        Task<bool> DeleteAsync(int id);
        
        /// <summary>
        /// Generate a new number for a domestic rating card
        /// </summary>
        Task<string> GenerateNewNumberAsync(int assetId);
    }
}
