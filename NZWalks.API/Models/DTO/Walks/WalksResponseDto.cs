namespace NZWalks.API.Models.DTO.Walks;

public class WalksResponseDto
{
    public IEnumerable<WalkResponseDto> Items { get; set; }
    public int TotalCount { get; set; }
}