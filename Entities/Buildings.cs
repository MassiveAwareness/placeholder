using backend.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Buildings
    {
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        [Required]
        public string BuildingTitle { get; set; } = string.Empty;

        [Required]
        public string BuildingImg { get; set; } = string.Empty;

        [Required]
        public int SiteId { get; set; }

        public Buildings UpdateBuildingDetailsAsync(string buildingTitle, string buildingImg, int siteId)
        {
            this.BuildingTitle = buildingTitle;
            this.BuildingImg = buildingImg;
            this.SiteId = siteId;

            return this;
        }

        public Buildings() {  }

        public Buildings(BuildingUpdateModel model)
        {
            Id = model.Id;
            BuildingTitle = model.BuildingTitle;
            BuildingImg = model.BuildingImg;
            SiteId = model.SiteId;
        }
    }
}
