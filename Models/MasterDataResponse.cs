namespace ValuationBackend.Models
{
    public class MasterDataResponse
    {
        public List<string> BuildingCategory { get; set; } = new();
        public List<string> BuildingClass { get; set; } = new();
        public List<string> Conviences { get; set; } = new();
        public List<string> NatureOfConstruction { get; set; } = new();
        public List<string> RoofMaterial { get; set; } = new();
        public List<string> RoofFrame { get; set; } = new();
        public List<string> RoofFinisher { get; set; } = new();
        public List<string> Celing { get; set; } = new();
        public List<string> FoundationStructure { get; set; } = new();
        public List<string> WallStructure { get; set; } = new();
        public List<string> FloorStructure { get; set; } = new();
        public List<string> Door { get; set; } = new();
        public List<string> Window { get; set; } = new();
        public List<string> WindowProtection { get; set; } = new();
        public List<string> DoorsBathroomAndToiletFittings { get; set; } = new();
        public List<string> DoorsHandRail { get; set; } = new();
        public List<string> DoorsPantryCupboard { get; set; } = new();
        public List<string> DoorsOther { get; set; } = new();
        public List<string> WallFinisher { get; set; } = new();
        public List<string> FloorFinisher { get; set; } = new();
        public List<string> BathroomAndToilet { get; set; } = new();
        public List<string> Services { get; set; } = new();
    }

    public class MasterDataItem
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
