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

    // GET
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] AddWalkRequestDto walkRequest)
    {
        var request = _mapper.Map<Walk>(walkRequest);
        var walk = await _repository.CreateAsync(request);

        var response = _mapper.Map<WalkResponseDto>(walk);

        return Ok(response);
    }
}