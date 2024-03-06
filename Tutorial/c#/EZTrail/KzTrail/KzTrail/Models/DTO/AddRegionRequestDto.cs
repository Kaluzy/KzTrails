using System.ComponentModel.DataAnnotations;

namespace KzTrail.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MaxLength(3, ErrorMessage = "Name has to be Max Char 3")]
        [MinLength(3, ErrorMessage = "Name has to be Max Char 3")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be Max Char 8")]
        [MinLength(8, ErrorMessage = "Name has to be Max Char 8")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }


    }
}
