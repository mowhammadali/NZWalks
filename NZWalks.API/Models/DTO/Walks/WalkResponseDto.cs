namespace NZWalks.API.Models.DTO.Walks;

public class WalkResponseDto
{
    public Guid Id { get; set; }
    public string WalkName { get; set; }
    public string Description { get; set; }
    public double LengthInKm { get; set; }
    public string WalkImageUrl { get; set; }
    public Guid DifficultyId { get; set; }
    public Guid RegionId { get; set; }
}