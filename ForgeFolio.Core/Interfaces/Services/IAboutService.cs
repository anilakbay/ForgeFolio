using ForgeFolio.Core.DTOs.About;

namespace ForgeFolio.Core.Interfaces.Services;

public interface IAboutService
{
    Task<AboutDto?> GetAboutAsync();
    Task UpdateAboutAsync(UpdateAboutDto dto);
}
