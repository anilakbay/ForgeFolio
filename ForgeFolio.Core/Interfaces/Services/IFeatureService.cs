using ForgeFolio.Core.DTOs.Feature;

namespace ForgeFolio.Core.Interfaces.Services;

public interface IFeatureService
{
    Task<IEnumerable<FeatureDto>> GetAllFeaturesAsync();
    Task<FeatureDto?> GetFeatureByIdAsync(int id);
    Task<FeatureDto> CreateFeatureAsync(CreateFeatureDto dto);
    Task UpdateFeatureAsync(int id, UpdateFeatureDto dto);
    Task DeleteFeatureAsync(int id);
}
