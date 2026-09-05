using NZWalks.API.Enums;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories;

public interface IWalkRepository
{
    Task<IEnumerable<Walk>> GetAllAsync(string? search, Guid? difficultyId, WalkSortBy? sortBy, bool isAscending);
    Task<Walk?> GetByIdAsync(Guid id);
    Task<Walk> CreateAsync(Walk request);
    Task<Walk?> UpdateAsync(Walk request, Guid id);
    Task<bool> DeleteAsync(Guid id);
}