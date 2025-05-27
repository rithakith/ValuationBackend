using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomesticRatingCardController : ControllerBase
    {
        private readonly IDomesticRatingCardService _service;

        public DomesticRatingCardController(IDomesticRatingCardService service)
        {
            _service = service;
        }

        // GET: api/DomesticRatingCard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DomesticRatingCardDto>>> GetAll()
        {
            try
            {
                var ratingCards = await _service.GetAllAsync();
                var result = ratingCards.Select(card => new DomesticRatingCardDto
                {
                    Id = card.Id,
                    AssetId = card.AssetId,
                    AssetNo = card.Asset?.AssetNo ?? "N/A",
                    NewNumber = card.NewNumber,
                    Owner = card.Owner,
                    Description = card.Description,
                    SelectWalls = card.SelectWalls,
                    Floor = card.Floor,
                    Conveniences = card.Conveniences,
                    Condition = card.Condition,
                    Age = card.Age,
                    Access = card.Access,
                    TsBop = card.TsBop ?? string.Empty,
                    ParkingSpace = card.ParkingSpace ?? string.Empty,
                    PropertySubCategory = card.PropertySubCategory,
                    PropertyType = card.PropertyType,
                    Plantations = card.Plantations ?? string.Empty,
                    WardNumber = card.WardNumber ?? string.Empty,
                    RoadName = card.RoadName ?? string.Empty,
                    Date = card.Date,
                    Occupier = card.Occupier ?? string.Empty,
                    RentPM = card.RentPM,
                    Terms = card.Terms ?? string.Empty,
                    SuggestedRate = card.SuggestedRate,
                    Notes = card.Notes ?? string.Empty,
                    CreatedAt = card.CreatedAt
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/DomesticRatingCard/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DomesticRatingCardDto>> GetById(int id)
        {
            try
            {
                var card = await _service.GetByIdAsync(id);
                if (card == null)
                {
                    return NotFound($"Domestic Rating Card with ID {id} not found.");
                }

                var result = new DomesticRatingCardDto
                {
                    Id = card.Id,
                    AssetId = card.AssetId,
                    AssetNo = card.Asset?.AssetNo ?? "N/A",
                    NewNumber = card.NewNumber,
                    Owner = card.Owner,
                    Description = card.Description,
                    SelectWalls = card.SelectWalls,
                    Floor = card.Floor,
                    Conveniences = card.Conveniences,
                    Condition = card.Condition,
                    Age = card.Age,
                    Access = card.Access,
                    TsBop = card.TsBop ?? string.Empty,
                    ParkingSpace = card.ParkingSpace ?? string.Empty,
                    PropertySubCategory = card.PropertySubCategory,
                    PropertyType = card.PropertyType,
                    Plantations = card.Plantations ?? string.Empty,
                    WardNumber = card.WardNumber ?? string.Empty,
                    RoadName = card.RoadName ?? string.Empty,
                    Date = card.Date,
                    Occupier = card.Occupier ?? string.Empty,
                    RentPM = card.RentPM,
                    Terms = card.Terms ?? string.Empty,
                    SuggestedRate = card.SuggestedRate,
                    Notes = card.Notes ?? string.Empty,
                    CreatedAt = card.CreatedAt
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("not found"))
                {
                    return NotFound(ex.Message);
                }
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/DomesticRatingCard/asset/5
        [HttpGet("asset/{assetId}")]
        public async Task<ActionResult<IEnumerable<DomesticRatingCardDto>>> GetByAssetId(int assetId)
        {
            try
            {
                var cards = await _service.GetByAssetIdAsync(assetId);
                var result = cards.Select(card => new DomesticRatingCardDto
                {
                    Id = card.Id,
                    AssetId = card.AssetId,
                    AssetNo = card.Asset?.AssetNo ?? "N/A",
                    NewNumber = card.NewNumber,
                    Owner = card.Owner,
                    Description = card.Description,
                    SelectWalls = card.SelectWalls,
                    Floor = card.Floor,
                    Conveniences = card.Conveniences,
                    Condition = card.Condition,
                    Age = card.Age,
                    Access = card.Access,
                    TsBop = card.TsBop ?? string.Empty,
                    ParkingSpace = card.ParkingSpace ?? string.Empty,
                    PropertySubCategory = card.PropertySubCategory,
                    PropertyType = card.PropertyType,
                    Plantations = card.Plantations ?? string.Empty,
                    WardNumber = card.WardNumber ?? string.Empty,
                    RoadName = card.RoadName ?? string.Empty,
                    Date = card.Date,
                    Occupier = card.Occupier ?? string.Empty,
                    RentPM = card.RentPM,
                    Terms = card.Terms ?? string.Empty,
                    SuggestedRate = card.SuggestedRate,
                    Notes = card.Notes ?? string.Empty,
                    CreatedAt = card.CreatedAt
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/DomesticRatingCard
        [HttpPost]
        public async Task<ActionResult<DomesticRatingCardDto>> Create(CreateDomesticRatingCardDto dto)
        {
            try
            {
                // Convert DTO to entity
                var domesticRatingCard = new DomesticRatingCard
                {
                    AssetId = dto.AssetId,
                    NewNumber = string.Empty, // Will be auto-generated in service
                    Owner = string.Empty, // Will be auto-filled in service
                    Description = string.Empty, // Will be auto-filled in service
                    SelectWalls = dto.SelectWalls,
                    Floor = dto.Floor,
                    Conveniences = dto.Conveniences,
                    Condition = dto.Condition,
                    Age = dto.Age,
                    Access = dto.Access,
                    TsBop = dto.TsBop,
                    ParkingSpace = dto.ParkingSpace,
                    PropertySubCategory = dto.PropertySubCategory,
                    PropertyType = dto.PropertyType,
                    Plantations = dto.Plantations,
                    WardNumber = dto.WardNumber,
                    RoadName = dto.RoadName,
                    Date = dto.Date,
                    Occupier = dto.Occupier,
                    RentPM = dto.RentPM,
                    Terms = dto.Terms,
                    SuggestedRate = dto.SuggestedRate,
                    Notes = dto.Notes
                };

                var createdCard = await _service.CreateAsync(domesticRatingCard);
                
                // Convert entity to DTO for response
                var responseDto = new DomesticRatingCardDto
                {
                    Id = createdCard.Id,
                    AssetId = createdCard.AssetId,
                    AssetNo = createdCard.Asset?.AssetNo ?? "N/A",
                    NewNumber = createdCard.NewNumber,
                    Owner = createdCard.Owner,
                    Description = createdCard.Description,
                    SelectWalls = createdCard.SelectWalls,
                    Floor = createdCard.Floor,
                    Conveniences = createdCard.Conveniences,
                    Condition = createdCard.Condition,
                    Age = createdCard.Age,
                    Access = createdCard.Access,
                    TsBop = createdCard.TsBop ?? string.Empty,
                    ParkingSpace = createdCard.ParkingSpace ?? string.Empty,
                    PropertySubCategory = createdCard.PropertySubCategory,
                    PropertyType = createdCard.PropertyType,
                    Plantations = createdCard.Plantations ?? string.Empty,
                    WardNumber = createdCard.WardNumber ?? string.Empty,
                    RoadName = createdCard.RoadName ?? string.Empty,
                    Date = createdCard.Date,
                    Occupier = createdCard.Occupier ?? string.Empty,
                    RentPM = createdCard.RentPM,
                    Terms = createdCard.Terms ?? string.Empty,
                    SuggestedRate = createdCard.SuggestedRate,
                    Notes = createdCard.Notes ?? string.Empty,
                    CreatedAt = createdCard.CreatedAt
                };
                
                return CreatedAtAction(nameof(GetById), new { id = createdCard.Id }, responseDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/DomesticRatingCard/5
        [HttpPut("{id}")]
        public async Task<ActionResult<DomesticRatingCardDto>> Update(int id, UpdateDomesticRatingCardDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch between route and body.");
            }

            try
            {
                // Get existing card
                var existingCard = await _service.GetByIdAsync(id);
                if (existingCard == null)
                {
                    return NotFound($"Domestic Rating Card with ID {id} not found.");
                }

                // Update entity from DTO
                existingCard.SelectWalls = dto.SelectWalls;
                existingCard.Floor = dto.Floor;
                existingCard.Conveniences = dto.Conveniences;
                existingCard.Condition = dto.Condition;
                existingCard.Age = dto.Age;
                existingCard.Access = dto.Access;
                existingCard.TsBop = dto.TsBop;
                existingCard.ParkingSpace = dto.ParkingSpace;
                existingCard.PropertySubCategory = dto.PropertySubCategory;
                existingCard.PropertyType = dto.PropertyType;
                existingCard.Plantations = dto.Plantations;
                existingCard.WardNumber = dto.WardNumber;
                existingCard.RoadName = dto.RoadName;
                existingCard.Date = dto.Date;
                existingCard.Occupier = dto.Occupier;
                existingCard.RentPM = dto.RentPM;
                existingCard.Terms = dto.Terms;
                existingCard.SuggestedRate = dto.SuggestedRate;
                existingCard.Notes = dto.Notes;

                var updatedCard = await _service.UpdateAsync(existingCard);
                
                // Convert entity to DTO for response
                var responseDto = new DomesticRatingCardDto
                {
                    Id = updatedCard.Id,
                    AssetId = updatedCard.AssetId,
                    AssetNo = updatedCard.Asset?.AssetNo ?? "N/A",
                    NewNumber = updatedCard.NewNumber,
                    Owner = updatedCard.Owner,
                    Description = updatedCard.Description,
                    SelectWalls = updatedCard.SelectWalls,
                    Floor = updatedCard.Floor,
                    Conveniences = updatedCard.Conveniences,
                    Condition = updatedCard.Condition,
                    Age = updatedCard.Age,
                    Access = updatedCard.Access,
                    TsBop = updatedCard.TsBop ?? string.Empty,
                    ParkingSpace = updatedCard.ParkingSpace ?? string.Empty,
                    PropertySubCategory = updatedCard.PropertySubCategory,
                    PropertyType = updatedCard.PropertyType,
                    Plantations = updatedCard.Plantations ?? string.Empty,
                    WardNumber = updatedCard.WardNumber ?? string.Empty,
                    RoadName = updatedCard.RoadName ?? string.Empty,
                    Date = updatedCard.Date,
                    Occupier = updatedCard.Occupier ?? string.Empty,
                    RentPM = updatedCard.RentPM,
                    Terms = updatedCard.Terms ?? string.Empty,
                    SuggestedRate = updatedCard.SuggestedRate,
                    Notes = updatedCard.Notes ?? string.Empty,
                    CreatedAt = updatedCard.CreatedAt
                };
                
                return Ok(responseDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("not found"))
                {
                    return NotFound(ex.Message);
                }
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/DomesticRatingCard/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                if (!result)
                {
                    return NotFound($"Domestic Rating Card with ID {id} not found.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
