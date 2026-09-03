using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO.Region;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<RegionResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(RegionResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(RegionResponseDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] AddRegionRequest addRegionRequest)
        {
            return Ok();
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(RegionResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateRegionRequest updateRegionRequest, [FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return Ok();
        }

    }
}
