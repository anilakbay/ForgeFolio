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
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<AboutDto?> GetAboutAsync()
    {
        var allAbout = await _repository.GetAllAsync();
        var about = allAbout.FirstOrDefault();
        
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

        await _unitOfWork.SaveChangesAsync();
    }
}
