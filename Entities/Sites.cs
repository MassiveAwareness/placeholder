using backend.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Sites
    {
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        [Required]
        public string SiteTitle { get; set; } = string.Empty;

        [Required]
        public string SiteImg { get; set; } = string.Empty;

        [Required]
        public int CityId { get; set; }

        public Sites UpdateSiteDetailsAsync(string siteTitle, string siteImg, int cityId)
        {
            this.SiteTitle = siteTitle;
            this.SiteImg = siteImg;
            this.CityId = cityId;

            return this;
        }

        public Sites() {  }

        public Sites(SiteUpdateModel model)
        {
            Id = model.Id;
            SiteTitle = model.SiteTitle;
            SiteImg = model.SiteImage;
            CityId = model.CityId;
        }
    }
}
