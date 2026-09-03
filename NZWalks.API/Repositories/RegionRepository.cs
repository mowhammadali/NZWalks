using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Regions;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public RegionRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Region>> GetAll()
        {
            IEnumerable<Region> regions = _dbContext.Regions.ToList();
            
            return regions;
        }

        public async Task<Region?> GetById(Guid id)
        {
            Region region = await _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

            if (region == null)
            {
                return null;
            }

            return region;
        }

        public async Task<Region> Create(Region regionRequest)
        {
            await _dbContext.Regions.AddAsync(regionRequest);
            await _dbContext.SaveChangesAsync();
            
            return regionRequest;
        }

        public async Task<Region?> Update(Region regionRequest, Guid id)
        {
            Region region = await _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

            if (region == null)
            {
                return null;
            }
            
            region.Name = regionRequest.Name;
            region.Code = regionRequest.Code;
            region.RegionImageUrl = regionRequest.RegionImageUrl;

            await _dbContext.SaveChangesAsync();
            
            return region;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            Region region = await _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

            if (region == null)
            {
                return false;
            }
            
            _dbContext.Regions.Remove(region);

            return true;
        }
    }
}