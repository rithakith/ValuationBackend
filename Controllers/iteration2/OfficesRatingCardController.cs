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
    public class OfficesRatingCardController : ControllerBase
    {
        private readonly IOfficesRatingCardService _service;

        public OfficesRatingCardController(IOfficesRatingCardService service)
        {
            _service = service;
        }

        // GET: api/OfficesRatingCard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficesRatingCardDto>>> GetAll()
        {
            try
            {
                var ratingCards = await _service.GetAllAsync();
                var result = ratingCards.Select(card => MapToDto(card));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/OfficesRatingCard/5
        [HttpGet("{id:int}", Name = "GetOfficesRatingCardById")]
        public async Task<ActionResult<OfficesRatingCardDto>> GetById(int id)
        {
            try
            {
                var card = await _service.GetByIdAsync(id);
                if (card == null)
                {
                    return NotFound($"Offices Rating Card with ID {id} not found.");
                }

                return Ok(MapToDto(card));
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

        // GET: api/OfficesRatingCard/asset/5
        [HttpGet("asset/{assetId:int}", Name = "GetOfficesRatingCardsByAssetId")]
        public async Task<ActionResult<IEnumerable<OfficesRatingCardDto>>> GetByAssetId(int assetId)
        {
            try
            {
                var cards = await _service.GetByAssetIdAsync(assetId);
                var result = cards.Select(card => MapToDto(card));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/OfficesRatingCard/asset/{assetId}
        [HttpPost("asset/{assetId:int}")]
        public async Task<ActionResult<OfficesRatingCardDto>> Create(
            int assetId,
            CreateOfficesRatingCardDto dto)
        {
            try
            {
                // Validate input parameters
                var validationResult = ValidateCreateOfficesRatingCardDto(assetId, dto);
                if (!validationResult.IsValid)
                {
                    return BadRequest(new 
                    { 
                        error = "Validation failed", 
                        details = validationResult.Errors 
                    });
                }

                // Convert DTO to entity
                var officesRatingCard = new OfficesRatingCard
                {
                    AssetId = assetId,
                    NewNumber = string.Empty, // Will be auto-generated in service
                    Owner = string.Empty, // Will be auto-filled in service
                    Description = string.Empty, // Will be auto-filled in service
                    BuildingSelection = dto.BuildingSelection,
                    LocalAuthority = dto.LocalAuthority,
                    LocalAuthorityCode = dto.LocalAuthorityCode,
                    AssessmentNumber = dto.AssessmentNumber,
                    ObsoleteNumber = dto.ObsoleteNumber,
                    WallType = dto.WallType,
                    FloorType = dto.FloorType,
                    Conveniences = dto.Conveniences,
                    Condition = dto.Condition,
                    Age = dto.Age,
                    AccessType = dto.AccessType,
                    OfficeGrade = dto.OfficeGrade,
                    ParkingSpace = dto.ParkingSpace,
                    PropertySubCategory = dto.PropertySubCategory,
                    PropertyType = dto.PropertyType,
                    WardNumber = dto.WardNumber,
                    RoadName = dto.RoadName,
                    Date = dto.Date.HasValue ? DateTime.SpecifyKind(dto.Date.Value, DateTimeKind.Utc) : null,
                    Occupier = dto.Occupier,
                    RentPM = dto.RentPM,
                    Terms = dto.Terms,
                    FloorNumber = dto.FloorNumber,
                    CeilingHeight = dto.CeilingHeight,
                    OfficeSuite = dto.OfficeSuite,
                    TotalArea = dto.TotalArea,
                    UsableFloorArea = dto.UsableFloorArea,
                    SuggestedRate = dto.SuggestedRate,
                    Notes = dto.Notes,
                };

                var createdCard = await _service.CreateAsync(officesRatingCard);

                return CreatedAtAction(nameof(GetById), new { id = createdCard.Id }, MapToDto(createdCard));
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

        // PUT: api/OfficesRatingCard/5
        [HttpPut("{id}")]
        public async Task<ActionResult<OfficesRatingCardDto>> Update(
            int id,
            UpdateOfficesRatingCardDto dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return BadRequest("ID mismatch");
                }

                // Convert DTO to entity
                var officesRatingCard = new OfficesRatingCard
                {
                    Id = dto.Id,
                    AssetId = dto.AssetId,
                    NewNumber = string.Empty, // Will be set by service
                    Owner = string.Empty, // Will be set by service
                    Description = string.Empty, // Will be set by service
                    BuildingSelection = dto.BuildingSelection,
                    LocalAuthority = dto.LocalAuthority,
                    LocalAuthorityCode = dto.LocalAuthorityCode,
                    AssessmentNumber = dto.AssessmentNumber,
                    ObsoleteNumber = dto.ObsoleteNumber,
                    WallType = dto.WallType,
                    FloorType = dto.FloorType,
                    Conveniences = dto.Conveniences,
                    Condition = dto.Condition,
                    Age = dto.Age,
                    AccessType = dto.AccessType,
                    OfficeGrade = dto.OfficeGrade,
                    ParkingSpace = dto.ParkingSpace,
                    PropertySubCategory = dto.PropertySubCategory,
                    PropertyType = dto.PropertyType,
                    WardNumber = dto.WardNumber,
                    RoadName = dto.RoadName,
                    Date = dto.Date.HasValue ? DateTime.SpecifyKind(dto.Date.Value, DateTimeKind.Utc) : null,
                    Occupier = dto.Occupier,
                    RentPM = dto.RentPM,
                    Terms = dto.Terms,
                    FloorNumber = dto.FloorNumber,
                    CeilingHeight = dto.CeilingHeight,
                    OfficeSuite = dto.OfficeSuite,
                    TotalArea = dto.TotalArea,
                    UsableFloorArea = dto.UsableFloorArea,
                    SuggestedRate = dto.SuggestedRate,
                    Notes = dto.Notes,
                };

                var updatedCard = await _service.UpdateAsync(officesRatingCard);

                return Ok(MapToDto(updatedCard));
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

        // DELETE: api/OfficesRatingCard/5
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

        // GET: api/OfficesRatingCard/autofill/{assetId}
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

        #region Helper Methods

        private OfficesRatingCardDto MapToDto(OfficesRatingCard card)
        {
            return new OfficesRatingCardDto
            {
                Id = card.Id,
                AssetId = card.AssetId,
                AssetNo = card.Asset?.AssetNo ?? "N/A",
                NewNumber = card.NewNumber,
                Owner = card.Owner,
                Description = card.Description,
                BuildingSelection = card.BuildingSelection,
                LocalAuthority = card.LocalAuthority,
                LocalAuthorityCode = card.LocalAuthorityCode,
                AssessmentNumber = card.AssessmentNumber,
                ObsoleteNumber = card.ObsoleteNumber,
                WallType = card.WallType,
                FloorType = card.FloorType,
                Conveniences = card.Conveniences,
                Condition = card.Condition,
                Age = card.Age,
                AccessType = card.AccessType,
                OfficeGrade = card.OfficeGrade,
                ParkingSpace = card.ParkingSpace,
                PropertySubCategory = card.PropertySubCategory,
                PropertyType = card.PropertyType,
                WardNumber = card.WardNumber,
                RoadName = card.RoadName,
                Date = card.Date,
                Occupier = card.Occupier,
                RentPM = card.RentPM,
                Terms = card.Terms,
                FloorNumber = card.FloorNumber,
                CeilingHeight = card.CeilingHeight,
                OfficeSuite = card.OfficeSuite,
                TotalArea = card.TotalArea,
                UsableFloorArea = card.UsableFloorArea,
                SuggestedRate = card.SuggestedRate,
                Notes = card.Notes,
                CreatedAt = card.CreatedAt,
            };
        }

        private ValidationResult ValidateCreateOfficesRatingCardDto(
            int assetId, 
            CreateOfficesRatingCardDto dto)
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

            // Validate numeric fields
            if (dto.WardNumber.HasValue && dto.WardNumber.Value < 0)
            {
                result.Errors.Add("Ward number cannot be negative.");
            }

            if (dto.FloorNumber.HasValue && dto.FloorNumber.Value < -10)
            {
                result.Errors.Add("Floor number cannot be less than -10.");
            }

            if (dto.CeilingHeight.HasValue && dto.CeilingHeight.Value <= 0)
            {
                result.Errors.Add("Ceiling height must be greater than 0.");
            }

            if (dto.TotalArea.HasValue && dto.TotalArea.Value <= 0)
            {
                result.Errors.Add("Total area must be greater than 0.");
            }

            if (dto.UsableFloorArea.HasValue && dto.UsableFloorArea.Value <= 0)
            {
                result.Errors.Add("Usable floor area must be greater than 0.");
            }

            if (dto.RentPM.HasValue && dto.RentPM.Value < 0)
            {
                result.Errors.Add("Rent per month cannot be negative.");
            }

            if (dto.SuggestedRate.HasValue && dto.SuggestedRate.Value < 0)
            {
                result.Errors.Add("Suggested rate cannot be negative.");
            }

            // Validate string length constraints
            if (!string.IsNullOrEmpty(dto.Notes) && dto.Notes.Length > 2000)
            {
                result.Errors.Add("Notes cannot exceed 2000 characters.");
            }

            if (!string.IsNullOrEmpty(dto.RoadName) && dto.RoadName.Length > 200)
            {
                result.Errors.Add("Road Name cannot exceed 200 characters.");
            }

            if (!string.IsNullOrEmpty(dto.Occupier) && dto.Occupier.Length > 200)
            {
                result.Errors.Add("Occupier cannot exceed 200 characters.");
            }

            if (!string.IsNullOrEmpty(dto.Terms) && dto.Terms.Length > 500)
            {
                result.Errors.Add("Terms cannot exceed 500 characters.");
            }
            
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