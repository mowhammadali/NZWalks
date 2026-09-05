using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Walks;

namespace NZWalks.API.Repositories;

public interface IWalkRepository
{
    Task<IEnumerable<Walk>> GetAllAsync();
    Task<Walk?> GetByIdAsync(Guid id);
    Task<Walk> CreateAsync(Walk request);
    Task<Walk?> UpdateAsync(Walk request, Guid id);
}