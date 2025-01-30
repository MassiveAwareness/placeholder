namespace backend.Models
{
    public class FloorUpdateModel
    {
        public int Id { get; set; }
        public string FloorTitle { get; set; } = string.Empty;
        public int BuildingId { get; set; }
    }
}
