using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Walks;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WalksController : ControllerBase
{
    private readonly IWalkRepository _repository;
    private readonly IMapper _mapper;

    public WalksController(IWalkRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(WalksResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var walks = await _repository.GetAllAsync();
        var response = _mapper.Map<WalksResponseDto>(walks);

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(WalkResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var walk = await _repository.GetByIdAsync(id);

        if (walk == null)
        {
            return NotFound();
        }

        var response = _mapper.Map<WalkResponseDto>(walk);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(WalkResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] AddWalkRequestDto walkRequest)
    {
        var request = _mapper.Map<Walk>(walkRequest);

        var walk = await _repository.CreateAsync(request);

        var createdWalk = await _repository.GetByIdAsync(walk.Id);

        var response = _mapper.Map<WalkResponseDto>(createdWalk);

        return CreatedAtAction(
            nameof(GetById),
            new { id = walk.Id },
            response
        );
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(WalkSummaryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromBody] UpdateWalkRequestDto walkRequest, [FromRoute] Guid id)
    {
        var request = _mapper.Map<Walk>(walkRequest);

        var walk = await _repository.UpdateAsync(request, id);

        if (walk is null) return NotFound();

        var response = _mapper.Map<WalkSummaryDto>(walk);

        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var isWalkDeleted = await _repository.DeleteAsync(id);

        return isWalkDeleted ? NoContent() : NotFound();
    }
}