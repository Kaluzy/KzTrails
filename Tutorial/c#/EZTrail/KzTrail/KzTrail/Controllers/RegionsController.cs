using AutoMapper;
using KzTrail.CustomActionFilters;
using KzTrail.Data;
using KzTrail.Models.Domain;
using KzTrail.Models.DTO;
using KzTrail.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace KzTrail.Controllers

{   //https://localhost:port/api/regions
    [Route("api/[controller]")]
    [ApiController]

    public class RegionsController : ControllerBase
    {
        private readonly KzTrailDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(KzTrailDbContext dbContext, IRegionRepository regionRepository,
              IMapper mapper, ILogger<RegionsController> logger)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }


        //GET ALL REGION
        // GET: https://localhost:port/api/regions
        [HttpGet]
        /*[Authorize(Roles = "Reader")]*/
        public async Task<IActionResult> GetAll()

        {
            logger.LogInformation("GetAll Regions Action method was invoked");
            logger.LogWarning("Warning log from Region controller");
            logger.LogError("Error log from Region Controller");

            // Get data from Db - Domain modls
            var regionsDomain = await regionRepository.GetAllAsync();
            //Return DTOs to client
            logger.LogInformation($"Finished Getting All Regions request with data: {JsonSerializer.Serialize(regionsDomain)}");

            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));



            // Map Domain Models to DTO
            /*var regionsDto = new List<RegionDto>();

            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            }*/

            // Map Domain Models to DTO
            //var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);


        }

        //Get single Region (get region by Id)
        //GET: http://localhost:portnumber/api/regions/{id}

        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);

            //Get data from Db - Domain Model
            var regionDomain = await regionRepository.GetByIdAsync(id);
            //dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionDomain == null)
            {
                return NotFound("Record not Found " + id);
            }


            /* var regionsDto = new RegionDto
             {
                 Id = regionDomain.Id,
                 Code = regionDomain.Code,
                 Name = regionDomain.Name,
                 RegionImageUrl = regionDomain.RegionImageUrl
             };*/

            //Map Domain Model to DTO
            return Ok(mapper.Map<RegionDto>(regionDomain));


        }

        //POST to create new Region
        //POST: https://localhost:portnumber/api/regions

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]

        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {


            // Map / Convert Dto to Domain Model
            var regionDomainModel = mapper.Map<Regions>(addRegionRequestDto);
            regionDomainModel = await regionRepository.createRegionAsync(regionDomainModel);

            // Map Domain model to Dto
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);


            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDto);




            // Map / Convert Dto to Domain Model
            /* var regionDomainModel = new Region
             {
                 Code = addRegionRequestDto.Code,
                 Name = addRegionRequestDto.Name,
                 RegionImageUrl = addRegionRequestDto.RegionImageUrl
             };*/


            // Use Domain Model to create Region Db Context
            //await dbContext.Regions.AddAsync(regionDomainModel);
            //await dbContext.SaveChangesAsync();




            // Map Domain model to Dto
            /* var regionDto = new RegionDto
             {
                 Id = regionDomainModel.Id,
                 Code = regionDomainModel.Code,
                 Name = regionDomainModel.Name,
                 RegionImageUrl = regionDomainModel.RegionImageUrl
             };*/

        }


        //update region
        //PUT: //https://localhost:port/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionsRequestDto updateRegionsRequest)
        {
            //Map DTO to Domain Model

            /*var regionDomainModel = new Region
            {
                Code = updateRegionsRequest.Code,
                Name = updateRegionsRequest.Name,
                RegionImageUrl = updateRegionsRequest.RegionImageUrl
            };
            
*/

            //Map DTO to Domain Model

            var regionDomainModel = mapper.Map<Regions>(updateRegionsRequest);


            regionDomainModel = await regionRepository.updateRegionAsync(id, regionDomainModel);


            if (regionDomainModel == null)
            {
                return NotFound(id);
            }


            // Convort Domain Model to DTO
            /* var regionDto = new RegionDto
             {
                 Id = regionDomainModel.Id,
                 Code = regionDomainModel.Code,
                 Name = regionDomainModel.Name,
                 RegionImageUrl = regionDomainModel.RegionImageUrl
             };*/

            return Ok(mapper.Map<RegionDto>(regionDomainModel));





        }


        //Delete Region
        //DELETE: //https://localhost:port/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)

        {
            //Delete REgion
            var regionDomainModel = await regionRepository.deleteRegionAsync(id);
            //await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionDomainModel == null)
            {
                return NotFound(id);
            }


            // Return deleted region
            // map Domain Model to dto

            /*var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };*/



            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }
    }

}
