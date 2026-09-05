using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data.EntityMapping;

public class DifficultyMapping : IEntityTypeConfiguration<Difficulty>
{
    public void Configure(EntityTypeBuilder<Difficulty> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name).HasMaxLength(50).IsRequired();
        builder.Property<DateTime>("CreatedDate").HasColumnName("CreatedAt").HasDefaultValueSql("(getdate())");

        List<Difficulty> difficulties = new List<Difficulty>()
        {
            new Difficulty()
            {
                Id = Guid.Parse("f47ac10b-58cc-4372-a567-0e02b2c3d479"),
                Name = "Easy"
            },

            new Difficulty()
            {
                Id = Guid.Parse("9c858901-8a57-4791-81fe-4c455b099bc9"),
                Name = "Medium"
            },

            new Difficulty()
            {
                Id = Guid.Parse("6ba7b810-9dad-41d1-80b4-00c04fd430c8"),
                Name = "Hard"
            }
        };

        builder.HasData(difficulties);
    }
}