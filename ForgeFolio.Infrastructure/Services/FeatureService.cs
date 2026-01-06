using ForgeFolio.Core.DTOs.Feature;
using ForgeFolio.Core.Entities;
using ForgeFolio.Core.Interfaces;
using ForgeFolio.Core.Interfaces.Services;

namespace ForgeFolio.Infrastructure.Services;

public class FeatureService : IFeatureService
{
    private readonly IRepository<Feature> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public FeatureService(IRepository<Feature> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<FeatureDto>> GetAllFeaturesAsync()
    {
        var features = await _repository.GetAllAsync();
        return features.Select(f => new FeatureDto
        {
            Id = f.Id,
            Title = f.Title,
            Description = f.Description,
            Icon = f.Icon
        });
    }

    public async Task<FeatureDto?> GetFeatureByIdAsync(int id)
    {
        var feature = await _repository.GetByIdAsync(id);
        if (feature == null) return null;

        return new FeatureDto
        {
            Id = feature.Id,
            Title = feature.Title,
            Description = feature.Description,
Icon = feature.Icon
        };
    }

    public async Task<FeatureDto> CreateFeatureAsync(CreateFeatureDto dto)
    {
        var feature = new Feature
        {
            Title = dto.Title,
            Description = dto.Description,
            Icon = dto.Icon
        };

        await _repository.AddAsync(feature);
        await _unitOfWork.SaveChangesAsync();

        return new FeatureDto
        {
            Id = feature.Id,
            Title = feature.Title,
            Description = feature.Description,
            Icon = feature.Icon
        };
    }

    public async Task UpdateFeatureAsync(int id, UpdateFeatureDto dto)
    {
        var feature = await _repository.GetByIdAsync(id);
        if (feature == null) throw new KeyNotFoundException($"Feature with ID {id} not found");

        feature.Title = dto.Title;
        feature.Description = dto.Description;
        feature.Icon = dto.Icon;

        await _repository.UpdateAsync(feature);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteFeatureAsync(int id)
    {
        await _repository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
