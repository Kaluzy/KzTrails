using System.ComponentModel.DataAnnotations;

namespace KzTrail.Models.DTO
{
    public class AddWalksRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be Max Char 8")]
        [MinLength(8, ErrorMessage = "Name has to be Max Char 8")]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripiton { get; set; }
        [Required]
        [Range(0, 20, ErrorMessage = "Distance must be between 0 and 10")]
        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }
    }
}
