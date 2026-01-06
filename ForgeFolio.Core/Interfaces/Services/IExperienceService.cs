using ForgeFolio.Core.DTOs.Experience;

namespace ForgeFolio.Core.Interfaces.Services;

/// <summary>
/// Service interface for Experience operations
/// </summary>
public interface IExperienceService
{
    Task<IEnumerable<ExperienceDto>> GetAllExperiencesAsync();
    Task<ExperienceDto?> GetExperienceByIdAsync(int id);
    Task<ExperienceDto> CreateExperienceAsync(CreateExperienceDto dto);
    Task UpdateExperienceAsync(int id, UpdateExperienceDto dto);
    Task DeleteExperienceAsync(int id);
}
