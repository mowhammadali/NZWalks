using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data.EntityMapping;

public class WalkMapping : IEntityTypeConfiguration<Walk>
{
    public void Configure(EntityTypeBuilder<Walk> builder)
    {
        builder.HasOne(x => x.Region)
            .WithMany(x => x.Walks)
            .HasForeignKey(x => x.RegionId)
            .OnDelete(DeleteBehavior.Restrict);

        List<Walk> walks = new List<Walk>()
        {
            new Walk()
            {
                Id = Guid.Parse("5f16afa0-e33f-4bef-1a9d-08df0b2dbd77"),
                Name = "Roy's Peak Track",
                Description =
                    "A challenging hike near Wanaka with spectacular panoramic views of Lake Wanaka and the surrounding Southern Alps.",
                LengthInKm = 16,
                WalkImageUrl = "https://dummyjson.com/image/800x600/228833/ffffff?text=Roy's+Peak+Track",
                RegionId = Guid.Parse("c4b82e17-6d39-4f25-9a71-3e8c5b2d604f"),
                DifficultyId = Guid.Parse("f47ac10b-58cc-4372-a567-0e02b2c3d479")
            },

            new Walk()
            {
                Id = Guid.Parse("c084fa5b-8caa-48d2-d26e-08df0b2e21f8"),
                Name = "Lake Waikaremoana Track",
                Description =
                    "A scenic multi-day hike through native forests with beautiful views of Lake Waikaremoana and the surrounding wilderness.",
                LengthInKm = 46,
                WalkImageUrl = "https://dummyjson.com/image/800x600/336699/ffffff?text=Lake+Waikaremoana+Track",
                RegionId = Guid.Parse("7d1f93a6-2c58-4e74-b9a3-5f6d8c1b2047"),
                DifficultyId = Guid.Parse("6ba7b810-9dad-41d1-80b4-00c04fd430c8")
            },

            new Walk()
            {
                Id = Guid.Parse("c720780a-1830-4b70-52ae-08df0b52e142"),
                Name = "Hooker Valley Track",
                Description =
                    "An easy and scenic walk through the Southern Alps with spectacular views of Aoraki Mount Cook, glaciers, rivers, and mountain landscapes.",
                LengthInKm = 10,
                WalkImageUrl = "https://dummyjson.com/image/800x600/884422/ffffff?text=Hooker+Valley+Track",
                RegionId = Guid.Parse("8f7c2d1a-5b34-4e91-a7c2-1d6f9b8e3a45"),
                DifficultyId = Guid.Parse("9c858901-8a57-4791-81fe-4c455b099bc9")
            },

            new Walk()
            {
                Id = Guid.Parse("215fc389-fa83-43b9-bb5e-08df0b5447cd"),
                Name = "Milford Track",
                Description =
                    "One of New Zealand's most famous multi-day hiking tracks through spectacular mountains, forests, and valleys.",
                LengthInKm = 53.5,
                WalkImageUrl = "https://dummyjson.com/image/800x600/225588/ffffff?text=Milford+Track",
                RegionId = Guid.Parse("8f7c2d1a-5b34-4e91-a7c2-1d6f9b8e3a45"),
                DifficultyId = Guid.Parse("9c858901-8a57-4791-81fe-4c455b099bc9")
            },

            new Walk()
            {
                Id = Guid.Parse("a13f6c92-7e41-4b85-9d26-5c8a17f304be"),
                Name = "Mount Taranaki Summit Track",
                Description =
                    "A challenging alpine hike offering spectacular views across Taranaki and the surrounding landscapes.",
                LengthInKm = 18.5,
                WalkImageUrl = "https://dummyjson.com/image/800x600/446688/ffffff?text=Mount+Taranaki+Summit+Track",
                RegionId = Guid.Parse("e5a27c91-4b63-48d0-8f35-1c7e9a2b6054"),
                DifficultyId = Guid.Parse("6ba7b810-9dad-41d1-80b4-00c04fd430c8")
            },

            new Walk()
            {
                Id = Guid.Parse("b72e491c-35a8-4f67-a129-8d6c20e5b743"),
                Name = "Mount Victoria Lookout",
                Description =
                    "A scenic and accessible walk through native bush leading to panoramic views over Wellington city and harbour.",
                LengthInKm = 5.2,
                WalkImageUrl = "https://dummyjson.com/image/800x600/228855/ffffff?text=Mount+Victoria+Lookout",
                RegionId = Guid.Parse("3a9e6c72-1f45-4b8d-b2c7-6e5a1d9f3048"),
                DifficultyId = Guid.Parse("f47ac10b-58cc-4372-a567-0e02b2c3d479")
            },

            new Walk()
            {
                Id = Guid.Parse("c46d8a21-9f53-47be-b630-1e7c95a2d804"),
                Name = "Hamilton River Walk",
                Description =
                    "A relaxing riverside walk through parks and native vegetation with beautiful views along the Waikato River.",
                LengthInKm = 8.4,
                WalkImageUrl = "https://dummyjson.com/image/800x600/338866/ffffff?text=Hamilton+River+Walk",
                RegionId = Guid.Parse("e5a27c91-4b63-48d0-8f35-1c7e9a2b6054"),
                DifficultyId = Guid.Parse("9c858901-8a57-4791-81fe-4c455b099bc9")
            },

            new Walk()
            {
                Id = Guid.Parse("d85b237a-61c4-49e8-a572-3f9b16c74028"),
                Name = "Waitakere Ranges Trail",
                Description =
                    "A beautiful forest trail through lush native bush with waterfalls, streams, and impressive coastal views.",
                LengthInKm = 12.7,
                WalkImageUrl = "https://dummyjson.com/image/800x600/557744/ffffff?text=Waitakere+Ranges+Trail",
                RegionId = Guid.Parse("8f7c2d1a-5b34-4e91-a7c2-1d6f9b8e3a45"),
                DifficultyId = Guid.Parse("9c858901-8a57-4791-81fe-4c455b099bc9")
            }
        };

        builder.HasData(walks);
    }
}