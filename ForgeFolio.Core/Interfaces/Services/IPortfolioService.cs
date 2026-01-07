using ForgeFolio.Core.DTOs.Portfolio;

namespace ForgeFolio.Core.Interfaces.Services;

/// <summary>
/// Service interface for Portfolio operations
/// </summary>
public interface IPortfolioService
{
    Task<IEnumerable<PortfolioDto>> GetAllPortfoliosAsync();
    // Note: Paginated method removed from interface to avoid Infrastructure dependency in Core
    // Pagination logic remains in PortfolioService implementation
    Task<PortfolioDto?> GetPortfolioByIdAsync(int id);
    Task<PortfolioDto> CreatePortfolioAsync(CreatePortfolioDto dto);
    Task UpdatePortfolioAsync(int id, UpdatePortfolioDto dto);
    Task DeletePortfolioAsync(int id);
}
