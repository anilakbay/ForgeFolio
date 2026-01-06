using ForgeFolio.Core.DTOs.Portfolio;

namespace ForgeFolio.Core.Interfaces.Services;

/// <summary>
/// Service interface for Portfolio operations
/// </summary>
public interface IPortfolioService
{
    Task<IEnumerable<PortfolioDto>> GetAllPortfoliosAsync();
    Task<Core.Common.PaginatedList<PortfolioDto>> GetAllPortfoliosPaginatedAsync(int pageIndex, int pageSize);
    Task<PortfolioDto?> GetPortfolioByIdAsync(int id);
    Task<PortfolioDto> CreatePortfolioAsync(CreatePortfolioDto dto);
    Task UpdatePortfolioAsync(int id, UpdatePortfolioDto dto);
    Task DeletePortfolioAsync(int id);
}
