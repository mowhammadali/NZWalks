using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data;

public class NZWalksAuthDbContext : IdentityDbContext
{
    public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var readerRoleId = "D8D0625D-F9F2-4735-82E2-725055BDE487";
        var writerRoleId = "BD4C6764-C70B-4C9F-B4AB-BC1396D85E9D";

        var roles = new List<IdentityRole>()
        {
            new IdentityRole()
            {
                Id = readerRoleId,
                ConcurrencyStamp = readerRoleId,
                Name = "Reader",
                NormalizedName = "Reader".ToUpper()
            },
            new IdentityRole()
            {
                Id = writerRoleId,
                ConcurrencyStamp = writerRoleId,
                Name = "Write",
                NormalizedName = "Write".ToUpper()
            }
        };
        
        builder.Entity<IdentityRole>().HasData(roles);
    }
}