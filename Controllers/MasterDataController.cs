using Microsoft.AspNetCore.Mvc;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MasterDataController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MasterDataController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<MasterDataResponse> GetMasterData()
        {
            var allItems = _context.MasterDataItems.ToList();

            var response = new MasterDataResponse
            {
                BuildingCategory = allItems.Where(i => i.Category == "buildingCategory").Select(i => i.Value).ToList(),
                BuildingClass = allItems.Where(i => i.Category == "buildingClass").Select(i => i.Value).ToList(),
                Conviences = allItems.Where(i => i.Category == "conviences").Select(i => i.Value).ToList(),
                NatureOfConstruction = allItems.Where(i => i.Category == "natureOfConstruction").Select(i => i.Value).ToList(),
                RoofMaterial = allItems.Where(i => i.Category == "roofMaterial").Select(i => i.Value).ToList(),
                RoofFrame = allItems.Where(i => i.Category == "roofFrame").Select(i => i.Value).ToList(),
                RoofFinisher = allItems.Where(i => i.Category == "roofFinisher").Select(i => i.Value).ToList(),
                Celing = allItems.Where(i => i.Category == "celing").Select(i => i.Value).ToList(),
                FoundationStructure = allItems.Where(i => i.Category == "foundationStructure").Select(i => i.Value).ToList(),
                WallStructure = allItems.Where(i => i.Category == "wallStructure").Select(i => i.Value).ToList(),
                FloorStructure = allItems.Where(i => i.Category == "floorStructure").Select(i => i.Value).ToList(),
                Door = allItems.Where(i => i.Category == "door").Select(i => i.Value).ToList(),
                Window = allItems.Where(i => i.Category == "window").Select(i => i.Value).ToList(),
                WindowProtection = allItems.Where(i => i.Category == "windowProtection").Select(i => i.Value).ToList(),
                DoorsBathroomAndToiletFittings = allItems.Where(i => i.Category == "doorsBathroomAndToiletFittings").Select(i => i.Value).ToList(),
                DoorsHandRail = allItems.Where(i => i.Category == "doorsHandRail").Select(i => i.Value).ToList(),
                DoorsPantryCupboard = allItems.Where(i => i.Category == "doorsPantryCupboard").Select(i => i.Value).ToList(),
                DoorsOther = allItems.Where(i => i.Category == "doorsOther").Select(i => i.Value).ToList(),
                WallFinisher = allItems.Where(i => i.Category == "wallFinisher").Select(i => i.Value).ToList(),
                FloorFinisher = allItems.Where(i => i.Category == "floorFinisher").Select(i => i.Value).ToList(),
                BathroomAndToilet = allItems.Where(i => i.Category == "bathroomAndToilet").Select(i => i.Value).ToList(),
                Services = allItems.Where(i => i.Category == "services").Select(i => i.Value).ToList()
            };

            return Ok(response);
        }
    }
}
