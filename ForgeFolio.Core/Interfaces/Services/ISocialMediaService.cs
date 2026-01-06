using ForgeFolio.Core.DTOs.SocialMedia;

namespace ForgeFolio.Core.Interfaces.Services;

public interface ISocialMediaService
{
    Task<IEnumerable<SocialMediaDto>> GetAllSocialMediasAsync();
    Task<SocialMediaDto?> GetSocialMediaByIdAsync(int id);
    Task CreateSocialMediaAsync(CreateSocialMediaDto dto);
    Task UpdateSocialMediaAsync(int id, UpdateSocialMediaDto dto);
    Task DeleteSocialMediaAsync(int id);
}
