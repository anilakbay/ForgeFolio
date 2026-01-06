using ForgeFolio.Core.DTOs.SocialMedia;
using ForgeFolio.Core.Entities;
using ForgeFolio.Core.Interfaces;
using ForgeFolio.Core.Interfaces.Services;

namespace ForgeFolio.Infrastructure.Services;

public class SocialMediaService : ISocialMediaService
{
    private readonly IRepository<SocialMedia> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public SocialMediaService(IRepository<SocialMedia> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<IEnumerable<SocialMediaDto>> GetAllSocialMediasAsync()
    {
        var items = await _repository.GetAllAsync();
        return items.Select(x => new SocialMediaDto
        {
            Id = x.Id,
            Title = x.Title,
            Url = x.Url,
            Icon = x.Icon
        });
    }

    public async Task<SocialMediaDto?> GetSocialMediaByIdAsync(int id)
    {
        var x = await _repository.GetByIdAsync(id);
        if (x == null) return null;

        return new SocialMediaDto
        {
            Id = x.Id,
            Title = x.Title,
            Url = x.Url,
            Icon = x.Icon
        };
    }

    public async Task CreateSocialMediaAsync(CreateSocialMediaDto dto)
    {
        var item = new SocialMedia
        {
            Title = dto.Title,
            Url = dto.Url,
            Icon = dto.Icon
        };

        await _repository.AddAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateSocialMediaAsync(int id, UpdateSocialMediaDto dto)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null)
            throw new Exception($"SocialMedia with ID {id} not found");

        item.Title = dto.Title;
        item.Url = dto.Url;
        item.Icon = dto.Icon;

        await _repository.UpdateAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteSocialMediaAsync(int id)
    {
        await _repository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
