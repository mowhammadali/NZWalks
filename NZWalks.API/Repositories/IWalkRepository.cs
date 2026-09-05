using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Walks;

namespace NZWalks.API.Repositories;

public interface IWalkRepository
{
    Task<Walk> CreateAsync(Walk request);
}