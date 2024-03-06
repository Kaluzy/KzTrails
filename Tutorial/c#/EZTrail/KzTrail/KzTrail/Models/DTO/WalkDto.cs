namespace KzTrail.Models.DTO
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Descripiton { get; set; }

        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }


        //Navigation Property
        public RegionDto? Region { get; set; }

        public DifficultyDto? Difficulty { get; set; }

    }
}
