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
<<<<<<< HEAD
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
=======
        _repository = repository;
        _unitOfWork = unitOfWork;
>>>>>>> anildev
    }

    public async Task<AboutDto?> GetAboutAsync()
    {
<<<<<<< HEAD
        var abouts = await _repository.GetAllAsync();
        var about = abouts.FirstOrDefault();
=======
        var allAbout = await _repository.GetAllAsync();
        var about = allAbout.FirstOrDefault();
        
>>>>>>> anildev
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
<<<<<<< HEAD
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
=======
        var allAbout = await _repository.GetAllAsync();
        var about = allAbout.FirstOrDefault();
        
        if (about == null)
        {
            about = new About
            {
                Title = dto.Title,
                SubDescription = dto.SubDescription,
                Details = dto.Details
            };
            await _repository.AddAsync(about);
        }
        else
        {
            about.Title = dto.Title;
            about.SubDescription = dto.SubDescription;
            about.Details = dto.Details;
            await _repository.UpdateAsync(about);
        }

>>>>>>> anildev
        await _unitOfWork.SaveChangesAsync();
    }
}
