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
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<SocialMediaDto>> GetAllSocialMediaAsync()
    {
        var socialMedias = await _repository.GetAllAsync();
        return socialMedias.Select(sm => new SocialMediaDto
        {
            Id = sm.Id,
            Title = sm.Title,
            Url = sm.Url,
            Icon = sm.Icon
        });
    }

    public async Task<SocialMediaDto?> GetSocialMediaByIdAsync(int id)
    {
        var socialMedia = await _repository.GetByIdAsync(id);
        if (socialMedia == null) return null;

        return new SocialMediaDto
        {
            Id = socialMedia.Id,
            Title = socialMedia.Title,
            Url = socialMedia.Url,
            Icon = socialMedia.Icon
        };
    }

    public async Task<SocialMediaDto> CreateSocialMediaAsync(CreateSocialMediaDto dto)
    {
        var socialMedia = new SocialMedia
        {
            Title = dto.Title,
            Url = dto.Url,
            Icon = dto.Icon
        };

        await _repository.AddAsync(socialMedia);
        await _unitOfWork.SaveChangesAsync();

        return new SocialMediaDto
        {
            Id = socialMedia.Id,
            Title = socialMedia.Title,
            Url = socialMedia.Url,
            Icon = socialMedia.Icon
        };
    }

    public async Task UpdateSocialMediaAsync(int id, UpdateSocialMediaDto dto)
    {
        var socialMedia = await _repository.GetByIdAsync(id);
        if (socialMedia == null) throw new KeyNotFoundException($"SocialMedia with ID {id} not found");

        socialMedia.Title = dto.Title;
        socialMedia.Url = dto.Url;
        socialMedia.Icon = dto.Icon;

        await _repository.UpdateAsync(socialMedia);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteSocialMediaAsync(int id)
    {
        await _repository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
