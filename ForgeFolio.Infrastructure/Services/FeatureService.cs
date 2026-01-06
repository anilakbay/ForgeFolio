using ForgeFolio.Core.DTOs.Feature;
using ForgeFolio.Core.Entities;
using ForgeFolio.Core.Interfaces;
using ForgeFolio.Core.Interfaces.Services;

namespace ForgeFolio.Infrastructure.Services;

using Microsoft.Extensions.Caching.Memory;
// ... (existing usings)

public class FeatureService : IFeatureService
{
    private readonly IRepository<Feature> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMemoryCache _cache;
    private const string CacheKey = "features_all";

    public FeatureService(IRepository<Feature> repository, IUnitOfWork unitOfWork, IMemoryCache cache)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public async Task<IEnumerable<FeatureDto>> GetAllFeaturesAsync()
    {
        if (!_cache.TryGetValue(CacheKey, out IEnumerable<FeatureDto> cachedFeatures))
        {
            var features = await _repository.GetAllAsync();
            cachedFeatures = features.Select(x => new FeatureDto
            {
                Id = x.Id,
                Title = x.Title,
                Header = x.Header,
                NameSurname = x.NameSurname,
                Description = x.Description,
                Icon = x.Icon
            }).ToList();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(30))
                .SetAbsoluteExpiration(TimeSpan.FromHours(1));

            _cache.Set(CacheKey, cachedFeatures, cacheEntryOptions);
        }

        return cachedFeatures;
    }

    public async Task<FeatureDto?> GetFeatureByIdAsync(int id)
    {
        // For individual items, we might check cache first if we cached by ID, 
        // but for now let's keep it simple or fetch from all-list if feasible. 
        // Standard repository call for now.
        var feature = await _repository.GetByIdAsync(id);
        if (feature == null) return null;

        return new FeatureDto
        {
            Id = feature.Id,
            Title = feature.Title,
            Header = feature.Header,
            NameSurname = feature.NameSurname,
            Description = feature.Description,
            Icon = feature.Icon
        };
    }

    public async Task<FeatureDto> CreateFeatureAsync(CreateFeatureDto dto)
    {
        var feature = new Feature
        {
            Title = dto.Title,
            Header = dto.Header,
            NameSurname = dto.NameSurname,
            Description = dto.Description,
            Icon = dto.Icon
        };

        await _repository.AddAsync(feature);
        await _unitOfWork.SaveChangesAsync();
        
        _cache.Remove(CacheKey); // Invalidate Cache

        return new FeatureDto
        {
            Id = feature.Id,
            Title = feature.Title,
            Header = feature.Header,
            NameSurname = feature.NameSurname,
            Description = feature.Description,
            Icon = feature.Icon
        };
    }

    public async Task UpdateFeatureAsync(int id, UpdateFeatureDto dto)
    {
        var feature = await _repository.GetByIdAsync(id);
        if (feature == null)
            throw new Exception($"Feature with ID {id} not found");

        feature.Title = dto.Title;
        feature.Header = dto.Header;
        feature.NameSurname = dto.NameSurname;
        feature.Description = dto.Description;
        feature.Icon = dto.Icon;

        await _repository.UpdateAsync(feature);
        await _unitOfWork.SaveChangesAsync();
        
        _cache.Remove(CacheKey); // Invalidate Cache
    }

    public async Task DeleteFeatureAsync(int id)
    {
        await _repository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
        
        _cache.Remove(CacheKey); // Invalidate Cache
    }
}
