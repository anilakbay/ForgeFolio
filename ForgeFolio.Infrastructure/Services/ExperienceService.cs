using ForgeFolio.Core.DTOs.Experience;
using ForgeFolio.Core.Entities;
using ForgeFolio.Core.Interfaces;
using ForgeFolio.Core.Interfaces.Services;

namespace ForgeFolio.Infrastructure.Services;

/// <summary>
/// Experience service implementation
/// </summary>
public class ExperienceService : IExperienceService
{
    private readonly IRepository<Experience> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ExperienceService(IRepository<Experience> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<IEnumerable<ExperienceDto>> GetAllExperiencesAsync()
    {
        var experiences = await _repository.GetAllAsync();
        return experiences.Select(e => new ExperienceDto
        {
            Id = e.Id,
            Head = e.Head,
            Title = e.Title,
            Date = e.Date,
            Description = e.Description,
            CreatedAt = e.CreatedAt
        });
    }

    public async Task<ExperienceDto?> GetExperienceByIdAsync(int id)
    {
        var experience = await _repository.GetByIdAsync(id);
        if (experience == null) return null;

        return new ExperienceDto
        {
            Id = experience.Id,
            Head = experience.Head,
            Title = experience.Title,
            Date = experience.Date,
            Description = experience.Description,
            CreatedAt = experience.CreatedAt
        };
    }

    public async Task<ExperienceDto> CreateExperienceAsync(CreateExperienceDto dto)
    {
        var experience = new Experience
        {
            Head = dto.Head,
            Title = dto.Title,
            Date = dto.Date,
            Description = dto.Description
        };

        await _repository.AddAsync(experience);
        await _unitOfWork.SaveChangesAsync();

        return new ExperienceDto
        {
            Id = experience.Id,
            Head = experience.Head,
            Title = experience.Title,
            Date = experience.Date,
            Description = experience.Description,
            CreatedAt = experience.CreatedAt
        };
    }

    public async Task UpdateExperienceAsync(int id, UpdateExperienceDto dto)
    {
        var experience = await _repository.GetByIdAsync(id);
        if (experience == null)
            throw new KeyNotFoundException($"Experience with ID {id} not found");

        experience.Head = dto.Head;
        experience.Title = dto.Title;
        experience.Date = dto.Date;
        experience.Description = dto.Description;

        await _repository.UpdateAsync(experience);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteExperienceAsync(int id)
    {
        await _repository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
