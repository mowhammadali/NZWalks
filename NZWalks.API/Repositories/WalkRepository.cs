using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Enums;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories;

public class WalkRepository : IWalkRepository
{
    private readonly NZWalksDbContext _dbContext;

    public WalkRepository(NZWalksDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Walk>> GetAllAsync(string? search = null, Guid? difficultyId = null,
        WalkSortBy? sortBy = null, bool isAscending = true)
    {
        // List<Walk> walks = await _dbContext.Walks.Include(w => w.Region).Include(w => w.Difficulty).ToListAsync();
        var walks = _dbContext.Walks.Include(w => w.Region).Include(w => w.Difficulty).AsQueryable();

        // Filtering
        if (!string.IsNullOrWhiteSpace(search))
        {
            walks = walks.Where(w => w.Name.Contains(search));
        }

        if (difficultyId != null)
        {
            walks = walks.Where(w => w.DifficultyId == difficultyId);
        }

        // Sorting
        if (sortBy == WalkSortBy.Name)
        {
            walks = isAscending ? walks.OrderBy(w => w.Name) : walks.OrderByDescending(w => w.Name);
        }

        if (sortBy == WalkSortBy.Length)
        {
            walks = isAscending ? walks.OrderBy(w => w.LengthInKm) : walks.OrderByDescending(w => w.LengthInKm);
        }

        return walks.ToList();
    }

    public async Task<Walk?> GetByIdAsync(Guid id)
    {
        var Walk = await _dbContext.Walks.Include(w => w.Region).Include(w => w.Difficulty)
            .FirstOrDefaultAsync(walk => walk.Id == id);

        return Walk;
    }

    public async Task<Walk> CreateAsync(Walk walkRequest)
    {
        await _dbContext.Walks.AddAsync(walkRequest);
        await _dbContext.SaveChangesAsync();

        return walkRequest;
    }

    public async Task<Walk?> UpdateAsync(Walk walkRequest, Guid id)
    {
        var walk = await _dbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);

        if (walk is null) return null;

        walk.Name = walkRequest.Name;
        walk.Description = walkRequest.Description;
        walk.LengthInKm = walkRequest.LengthInKm;
        walk.WalkImageUrl = walkRequest.WalkImageUrl;
        walk.DifficultyId = walkRequest.DifficultyId;
        walk.RegionId = walkRequest.RegionId;

        await _dbContext.SaveChangesAsync();
        return walk;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var ExisingWalk = await _dbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);

        if (ExisingWalk is null)
        {
            return false;
        }

        _dbContext.Walks.Remove(ExisingWalk);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}