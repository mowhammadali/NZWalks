using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Regions;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(RegionsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Region> regions = await _regionRepository.GetAll();

            RegionsResponse response = _mapper.Map<RegionsResponse>(regions);

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(RegionResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            Region region = await _regionRepository.GetById(id);

            if (region == null)
            {
                return NotFound();
            }

            RegionResponseDto response = _mapper.Map<RegionResponseDto>(region);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(RegionResponseDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] AddRegionRequest addRegionRequest)
        {
            Region mappedToRegion = _mapper.Map<Region>(addRegionRequest);

            Region region = await _regionRepository.Create(mappedToRegion);

            RegionResponseDto response = _mapper.Map<RegionResponseDto>(region);

            return CreatedAtAction(nameof(GetById), new { id = region.Id }, response);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(RegionResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateRegionRequest updateRegionRequest, [FromRoute] Guid id)
        {
            Region mappedToRegion = _mapper.Map<Region>(updateRegionRequest);

            Region region = await _regionRepository.Update(mappedToRegion, id);

            if (region == null)
            {
                return NotFound();
            }

            RegionResponseDto response = _mapper.Map<RegionResponseDto>(region);

            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            bool isDeleted = await _regionRepository.DeleteById(id);

            return isDeleted ? NoContent() : NotFound();
        }
    }
}