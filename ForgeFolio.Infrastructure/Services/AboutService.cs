using ForgeFolio.Core.DTOs.About;
using ForgeFolio.Core.Entities;
using ForgeFolio.Core.Interfaces;
using ForgeFolio.Core.Interfaces.Services;

namespace ForgeFolio.Infrastructure.Services;

public class AboutService : IAboutService
{
    private readonly IRepository<About> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public AboutService(IRepository<About> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<AboutDto?> GetAboutAsync()
    {
        var abouts = await _repository.GetAllAsync();
        var about = abouts.FirstOrDefault();
        if (about == null) return null;

        return new AboutDto
        {
            Id = about.Id,
            Title = about.Title,
            SubDescription = about.SubDescription,
            Details = about.Details
        };
    }

    public async Task UpdateAboutAsync(UpdateAboutDto dto)
    {
        var about = await _repository.GetByIdAsync(dto.Id);
        
        // If not exists (first time), check if we can add? Usually About is singleton-ish in portfolio
        if (about == null)
        {
             // Fallback: check if ANY exist, if not create new?
             // Or assume ID matches.
             // Let's assume Update implies existing.
             // But if we want to support "Create if not exists" logic:
             var all = await _repository.GetAllAsync();
             if (!all.Any())
             {
                 var newAbout = new About
                 {
                     Title = dto.Title,
                     SubDescription = dto.SubDescription,
                     Details = dto.Details
                 };
                 await _repository.AddAsync(newAbout);
                 await _unitOfWork.SaveChangesAsync();
                 return;
             }
             throw new KeyNotFoundException($"About with ID {dto.Id} not found");
        }

        about.Title = dto.Title;
        about.SubDescription = dto.SubDescription;
        about.Details = dto.Details;

        await _repository.UpdateAsync(about);
        await _unitOfWork.SaveChangesAsync();
    }
}
