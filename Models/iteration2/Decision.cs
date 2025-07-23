public class DecisionField
{
    public int Id { get; set; }
    public string Field { get; set; }              // E.g., "Zone"
    public string FieldDescription { get; set; }   // E.g., "Zoning Category"
    public string FieldType { get; set; }          // E.g., "string", "number"
    public int FieldSize { get; set; }             // E.g., 255
}
