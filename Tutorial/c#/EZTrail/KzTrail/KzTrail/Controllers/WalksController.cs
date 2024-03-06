using AutoMapper;
using KzTrail.CustomActionFilters;
using KzTrail.Models.Domain;
using KzTrail.Models.DTO;
using KzTrail.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KzTrail.Controllers
{   //https://localhost:port/api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;
        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }



        //Create walk
        //POST: /api/walks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalksRequestDto addWalksRequestDto)
        {
            var walkDomainModel = mapper.Map<Walk>(addWalksRequestDto);

            //Map DTO to Domain model

            await walkRepository.CreateAsync(walkDomainModel);


            //Mapt Domain Model to DTO

            return Ok(mapper.Map<WalkDto>(walkDomainModel));




        }

        //Get All Walks
        //GET: /api/walks
        //GET: /api/walks/?filterOn=Name&filterQuery=Track&sortBy=Name&IsAscending=true&pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {

            //Map Domain Model to Dto 
            var walkDomainModel = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            //Creat an test exception
            throw new Exception("This is exception from Walks Controller");


            //Return Dto to Client
            return Ok(mapper.Map<List<WalkDto>>(walkDomainModel));


        }

        //Get Walk By Id
        //GET: /api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //Get data from Domain Model
            var walkDomainModel = await walkRepository.GetByIdAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound("Record not found " + id);

            }

            //Convert Domain Model to DTO

            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }


        //Update Walk by id
        //PUT: /api/walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalks([FromRoute] Guid id, [FromBody] UpdateWalksRequestDto updateWalksRequestDto)
        {


            //map Dto to Domain Model 
            var walkDomainModel = mapper.Map<Walk>(updateWalksRequestDto);

            walkDomainModel = await walkRepository.updateWalkAsync(id, walkDomainModel);
            if (walkDomainModel == null)
            {
                return NotFound("Record not found " + id);
            }
            //Map Domain Model to Dto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));



        }

        //Delete Walk by Id
        //DELETE /api/walks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteWalks([FromRoute] Guid id)
        {
            var deletedwalkDomainModel = await walkRepository.deleteWalkAsync(id);
            if (deletedwalkDomainModel == null)
            {
                return NotFound("Record not found " + id);
            }

            //Map and return Domain Model to Dto
            return Ok(mapper.Map<WalkDto>(deletedwalkDomainModel));


        }
    }
}
