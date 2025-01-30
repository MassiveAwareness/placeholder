namespace backend.Models
{
    public class BuildingUpdateModel
    {
        public int Id { get; set; }
        public string BuildingTitle { get; set; } = string.Empty;
        public string BuildingImg { get; set; } = string.Empty;
        public int SiteId { get; set; }
    }
}
