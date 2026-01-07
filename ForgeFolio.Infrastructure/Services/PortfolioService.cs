using ForgeFolio.Core.DTOs.Portfolio;
using ForgeFolio.Core.Entities;
using ForgeFolio.Core.Interfaces;
using ForgeFolio.Core.Interfaces.Services;
using ForgeFolio.Infrastructure.Common;

namespace ForgeFolio.Infrastructure.Services;

/// <summary>
/// Portfolio service implementation
/// </summary>
public class PortfolioService : IPortfolioService
{
    private readonly IRepository<Portfolio> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public PortfolioService(IRepository<Portfolio> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<IEnumerable<PortfolioDto>> GetAllPortfoliosAsync()
    {
        var portfolios = await _repository.GetAllAsync();
        return portfolios.Select(p => new PortfolioDto
        {
            Id = p.Id,
            Title = p.Title,
            SubTitle = p.SubTitle,
            ImageUrl = p.ImageUrl,
            Url = p.Url,
            Description = p.Description,
            CreatedAt = p.CreatedAt
        });
    }

    public async Task<PaginatedList<PortfolioDto>> GetAllPortfoliosPaginatedAsync(int pageIndex, int pageSize)
    {
        var query = _repository.GetQueryable().Select(p => new PortfolioDto
        {
            Id = p.Id,
            Title = p.Title,
            SubTitle = p.SubTitle,
            ImageUrl = p.ImageUrl,
            Url = p.Url,
            Description = p.Description,
            CreatedAt = p.CreatedAt
        });

        // Add default ordering
        query = query.OrderByDescending(x => x.CreatedAt);

        return await PaginatedList<PortfolioDto>.CreateAsync(query, pageIndex, pageSize);
    }

    public async Task<PortfolioDto?> GetPortfolioByIdAsync(int id)
    {
        var portfolio = await _repository.GetByIdAsync(id);
        if (portfolio == null) return null;

        return new PortfolioDto
        {
            Id = portfolio.Id,
            Title = portfolio.Title,
            SubTitle = portfolio.SubTitle,
            ImageUrl = portfolio.ImageUrl,
            Url = portfolio.Url,
            Description = portfolio.Description,
            CreatedAt = portfolio.CreatedAt
        };
    }

    public async Task<PortfolioDto> CreatePortfolioAsync(CreatePortfolioDto dto)
    {
        var portfolio = new Portfolio
        {
            Title = dto.Title,
            SubTitle = dto.SubTitle,
            ImageUrl = dto.ImageUrl,
            Url = dto.Url,
            Description = dto.Description
        };

        await _repository.AddAsync(portfolio);
        await _unitOfWork.SaveChangesAsync();

        return new PortfolioDto
        {
            Id = portfolio.Id,
            Title = portfolio.Title,
            SubTitle = portfolio.SubTitle,
            ImageUrl = portfolio.ImageUrl,
            Url = portfolio.Url,
            Description = portfolio.Description,
            CreatedAt = portfolio.CreatedAt
        };
    }

    public async Task UpdatePortfolioAsync(int id, UpdatePortfolioDto dto)
    {
        var portfolio = await _repository.GetByIdAsync(id);
        if (portfolio == null)
            throw new KeyNotFoundException($"Portfolio with ID {id} not found");

        portfolio.Title = dto.Title;
        portfolio.SubTitle = dto.SubTitle;
        portfolio.ImageUrl = dto.ImageUrl;
        portfolio.Url = dto.Url;
        portfolio.Description = dto.Description;

        await _repository.UpdateAsync(portfolio);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeletePortfolioAsync(int id)
    {
        await _repository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
