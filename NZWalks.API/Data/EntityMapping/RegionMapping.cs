using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data.EntityMapping;

public class RegionMapping : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).HasMaxLength(32).IsRequired();
        builder.Property(p => p.Code).HasMaxLength(8).IsRequired();
        builder.Property<DateTime>("DateCreated").HasColumnName("CreatedAt").HasDefaultValue("getdate()");

        List<Region> regions = new List<Region>()
        {
            new Region()
            {
                Id = Guid.Parse("8f7c2d1a-5b34-4e91-a7c2-1d6f9b8e3a45"),
                Name = "Auckland",
                Code = "AKL",
                RegionImageUrl = "https://dummyjson.com/image/800x600/0088cc/ffffff?text=Auckland"
            },

            new Region()
            {
                Id = Guid.Parse("3a9e6c72-1f45-4b8d-b2c7-6e5a1d9f3048"),
                Name = "Wellington",
                Code = "WGN",
                RegionImageUrl = "https://dummyjson.com/image/800x600/44aa88/ffffff?text=Wellington"
            },

            new Region()
            {
                Id = Guid.Parse("c4b82e17-6d39-4f25-9a71-3e8c5b2d604f"),
                Name = "Canterbury",
                Code = "CAN",
                RegionImageUrl = "https://dummyjson.com/image/800x600/aa8844/ffffff?text=Canterbury"
            },

            new Region()
            {
                Id = Guid.Parse("7d1f93a6-2c58-4e74-b9a3-5f6d8c1b2047"),
                Name = "Otago",
                Code = "OTA",
                RegionImageUrl = "https://dummyjson.com/image/800x600/6644aa/ffffff?text=Otago"
            },

            new Region()
            {
                Id = Guid.Parse("e5a27c91-4b63-48d0-8f35-1c7e9a2b6054"),
                Name = "Waikato",
                Code = "WKO",
                RegionImageUrl = "https://dummyjson.com/image/800x600/aa4466/ffffff?text=Waikato"
            }
        };

        builder.HasData(regions);
    }
}