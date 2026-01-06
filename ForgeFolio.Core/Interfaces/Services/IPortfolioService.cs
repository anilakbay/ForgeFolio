namespace ForgeFolio.Core.Interfaces.Services;

/// <summary>
/// Service interface for Portfolio operations
/// </summary>
public interface IPortfolioService
{
    Task<IEnumerable<PortfolioDto>> GetAllPortfoliosAsync();
    Task<PortfolioDto?> GetPortfolioByIdAsync(int id);
    Task<PortfolioDto> CreatePortfolioAsync(CreatePortfolioDto dto);
    Task UpdatePortfolioAsync(int id, UpdatePortfolioDto dto);
    Task DeletePortfolioAsync(int id);
}

public class PortfolioDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? SubTitle { get; set; }
    public string? ImageUrl { get; set; }
    public string? Url { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CreatePortfolioDto
{
    public string Title { get; set; } = string.Empty;
    public string? SubTitle { get; set; }
    public string? ImageUrl { get; set; }
    public string? Url { get; set; }
    public string? Description { get; set; }
}

public class UpdatePortfolioDto
{
    public string Title { get; set; } = string.Empty;
    public string? SubTitle { get; set; }
    public string? ImageUrl { get; set; }
    public string? Url { get; set; }
    public string? Description { get; set; }
}
