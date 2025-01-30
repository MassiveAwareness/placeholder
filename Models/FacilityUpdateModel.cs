namespace backend.Models
{
    public class FacilityUpdateModel
    {
        public int Id { get; set; }
        public string Attributes { get; set; } = string.Empty;
        public int Value { get; set; }
        public int RoomId { get; set; }
    }
}