using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Difficulties;

namespace NZWalks.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DifficultiesController : ControllerBase
{
    private readonly NZWalksDbContext _dbContext;
    private readonly IMapper _mapper;

    public DifficultiesController(NZWalksDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<Difficulty> difficulties = await _dbContext.Difficulties.ToListAsync();

        List<DifficultyResponseDto> response = _mapper.Map<List<DifficultyResponseDto>>(difficulties);

        return Ok(response);
    }
}