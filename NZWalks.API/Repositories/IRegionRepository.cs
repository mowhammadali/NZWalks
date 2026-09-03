using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAll();
        Task<Region?> GetById(Guid id);
        Task<Region> Create(Region request);
        Task<Region?> Update(Region request, Guid id);
        Task<bool> DeleteById(Guid id);
    }
}
