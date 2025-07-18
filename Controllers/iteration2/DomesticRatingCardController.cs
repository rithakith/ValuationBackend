using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
                    CreatedAt = card.CreatedAt,
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/DomesticRatingCard/5
        [HttpGet("{id:int}", Name = "GetDomesticRatingCardById")]
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
                    CreatedAt = card.CreatedAt,
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
        }        // GET: api/DomesticRatingCard/asset/5
        [HttpGet("asset/{assetId:int}", Name = "GetDomesticRatingCardsByAssetId")]
        public async Task<ActionResult<IEnumerable<DomesticRatingCardDto>>> GetByAssetId(
            int assetId
        )
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
                    CreatedAt = card.CreatedAt,
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }        }

        // POST: api/DomesticRatingCard/asset/{assetId}
        [HttpPost("asset/{assetId:int}")]
        public async Task<ActionResult<DomesticRatingCardDto>> Create(
            int assetId,
            CreateDomesticRatingCardDto dto
        )
        {
            try
            {
                // Validate input parameters
                var validationResult = ValidateCreateDomesticRatingCardDto(assetId, dto);
                if (!validationResult.IsValid)
                {
                    return BadRequest(new 
                    { 
                        error = "Validation failed", 
                        details = validationResult.Errors 
                    });
                }                // Convert DTO to entity
                var domesticRatingCard = new DomesticRatingCard
                {
                    AssetId = assetId, // Use the assetId from the route parameter
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
                    Date = dto.Date.HasValue ? DateTime.SpecifyKind(dto.Date.Value, DateTimeKind.Utc) : null,
                    Occupier = dto.Occupier,
                    RentPM = dto.RentPM,
                    Terms = dto.Terms,
                    SuggestedRate = dto.SuggestedRate,
                    Notes = dto.Notes,
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
                    CreatedAt = createdCard.CreatedAt,
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
        public async Task<ActionResult<DomesticRatingCardDto>> Update(
            int id,
            UpdateDomesticRatingCardDto dto
        )
        {
            try
            {
                if (id != dto.Id)
                {
                    return BadRequest("ID mismatch");
                }

                // Convert DTO to entity
                var domesticRatingCard = new DomesticRatingCard
                {
                    Id = dto.Id,
                    AssetId = dto.AssetId,
                    NewNumber = string.Empty, // Will be set by service
                    Owner = string.Empty, // Will be set by service
                    Description = string.Empty, // Will be set by service
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
                    Date = dto.Date.HasValue ? DateTime.SpecifyKind(dto.Date.Value, DateTimeKind.Utc) : null,
                    Occupier = dto.Occupier,
                    RentPM = dto.RentPM,
                    Terms = dto.Terms,
                    SuggestedRate = dto.SuggestedRate,
                    Notes = dto.Notes,
                };

                var updatedCard = await _service.UpdateAsync(domesticRatingCard);

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
                    CreatedAt = updatedCard.CreatedAt,
                };

                return Ok(responseDto);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/DomesticRatingCard/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/DomesticRatingCard/autofill/{assetId}
        [HttpGet("autofill/{assetId:int}")]
        public async Task<ActionResult<AutofillDataDto>> GetAutofillData(int assetId)
        {
            try
            {
                var asset = await _service.GetAssetByIdAsync(assetId);
                if (asset == null)
                {
                    return NotFound($"Asset with ID {assetId} not found.");
                }
                var newNumber = await _service.GenerateNewNumberAsync(assetId);

                var autofillData = new AutofillDataDto
                {
                    Owner = asset.Owner,
                    Description = asset.Description.ToString(),
                    NewNumber = newNumber,
                };

                return Ok(autofillData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        #region Validation Methods

        private ValidationResult ValidateCreateDomesticRatingCardDto(
            int assetId, 
            CreateDomesticRatingCardDto dto
        )
        {
            var result = new ValidationResult();

            // Validate AssetId
            if (assetId <= 0)
            {
                result.Errors.Add("Asset ID must be a positive integer greater than 0.");
            }

            // Validate DTO is not null
            if (dto == null)
            {
                result.Errors.Add("Request body cannot be null.");
                return result;
            }

            // Validate Age (if provided)
            if (dto.Age.HasValue)
            {
                if (dto.Age.Value < 0)
                {
                    result.Errors.Add("Age cannot be negative.");
                }
                else if (dto.Age.Value > 500)
                {
                    result.Errors.Add("Age cannot exceed 500 years.");
                }
            }

            // Validate Date (if provided)
            if (dto.Date.HasValue)
            {
                if (dto.Date.Value < new DateTime(1800, 1, 1))
                {
                    result.Errors.Add("Date cannot be earlier than January 1, 1800.");
                }
                else if (dto.Date.Value > DateTime.UtcNow.AddYears(1))
                {
                    result.Errors.Add("Date cannot be more than 1 year in the future.");
                }
            }

            // Validate RentPM (if provided)
            if (dto.RentPM.HasValue)
            {
                if (dto.RentPM.Value < 0)
                {
                    result.Errors.Add("Rent per month cannot be negative.");
                }
                else if (dto.RentPM.Value > 1000000)
                {
                    result.Errors.Add("Rent per month cannot exceed 1,000,000.");
                }
            }

            // Validate SuggestedRate (if provided)
            if (dto.SuggestedRate.HasValue)
            {
                if (dto.SuggestedRate.Value < 0)
                {
                    result.Errors.Add("Suggested rate cannot be negative.");
                }
                else if (dto.SuggestedRate.Value > 10000000)
                {
                    result.Errors.Add("Suggested rate cannot exceed 10,000,000.");
                }
            }

            // Validate string length constraints
            if (!string.IsNullOrEmpty(dto.TsBop) && dto.TsBop.Length > 500)
            {
                result.Errors.Add("TsBop cannot exceed 500 characters.");
            }

            if (!string.IsNullOrEmpty(dto.ParkingSpace) && dto.ParkingSpace.Length > 500)
            {
                result.Errors.Add("ParkingSpace cannot exceed 500 characters.");
            }

            if (!string.IsNullOrEmpty(dto.Plantations) && dto.Plantations.Length > 1000)
            {
                result.Errors.Add("Plantations cannot exceed 1000 characters.");
            }

            if (!string.IsNullOrEmpty(dto.WardNumber) && dto.WardNumber.Length > 50)
            {
                result.Errors.Add("Ward Number cannot exceed 50 characters.");
            }

            if (!string.IsNullOrEmpty(dto.RoadName) && dto.RoadName.Length > 200)
            {
                result.Errors.Add("Road Name cannot exceed 200 characters.");
            }

            if (!string.IsNullOrEmpty(dto.Occupier) && dto.Occupier.Length > 200)
            {
                result.Errors.Add("Occupier cannot exceed 200 characters.");
            }            if (!string.IsNullOrEmpty(dto.Terms) && dto.Terms.Length > 500)
            {
                result.Errors.Add("Terms cannot exceed 500 characters.");
            }

            if (!string.IsNullOrEmpty(dto.Notes) && dto.Notes.Length > 2000)
            {
                result.Errors.Add("Notes cannot exceed 2000 characters.");
            }

            // String properties are now optional and can contain any valid string values
            // Additional validation for specific values can be added here if needed
            
            return result;
        }

        #endregion

        #region Helper Classes

        private class ValidationResult
        {
            public bool IsValid => !Errors.Any();
            public List<string> Errors { get; set; } = new List<string>();
        }

        #endregion
    }
}
