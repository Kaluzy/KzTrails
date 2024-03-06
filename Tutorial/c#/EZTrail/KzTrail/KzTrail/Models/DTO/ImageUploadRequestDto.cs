using System.ComponentModel.DataAnnotations;

namespace KzTrail.Models.DTO
{
    public class ImageUploadRequestDto
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }
        public string? FildDescripion { get; set; }
    }
}
