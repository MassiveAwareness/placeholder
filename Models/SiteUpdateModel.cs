namespace backend.Models
{
    public class SiteUpdateModel
    {
        public int Id { get; set; }
        public string SiteTitle { get; set; } = string.Empty;
        public string SiteImage { get; set; } = string.Empty;
        public int CityId { get; set; }
    }
}
