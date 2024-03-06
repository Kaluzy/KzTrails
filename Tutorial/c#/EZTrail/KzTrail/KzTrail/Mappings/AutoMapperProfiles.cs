using AutoMapper;
using KzTrail.Models.Domain;
using KzTrail.Models.DTO;

namespace KzTrail.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Mapping Domain Model to DTO
            CreateMap<Regions, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Regions>().ReverseMap();
            CreateMap<UpdateRegionsRequestDto, Regions>().ReverseMap();

            CreateMap<AddWalksRequestDto, Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            CreateMap<UpdateWalksRequestDto, Walk>().ReverseMap();
        }
    }
}
