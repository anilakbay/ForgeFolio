using ForgeFolio.Core.DTOs.Testimonial;
using ForgeFolio.Core.Entities;
using ForgeFolio.Core.Interfaces;
using ForgeFolio.Core.Interfaces.Services;

namespace ForgeFolio.Infrastructure.Services;

public class TestimonialService : ITestimonialService
{
    private readonly IRepository<Testimonial> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public TestimonialService(IRepository<Testimonial> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<IEnumerable<TestimonialDto>> GetAllTestimonialsAsync()
    {
        var items = await _repository.GetAllAsync();
        return items.Select(x => new TestimonialDto
        {
            Id = x.Id,
            ClientName = x.ClientName,
            Comment = x.Comment,
            CompanyName = x.CompanyName,
            ImageUrl = x.ImageUrl
        });
    }

    public async Task<TestimonialDto?> GetTestimonialByIdAsync(int id)
    {
        var x = await _repository.GetByIdAsync(id);
        if (x == null) return null;

        return new TestimonialDto
        {
            Id = x.Id,
            ClientName = x.ClientName,
            Comment = x.Comment,
            CompanyName = x.CompanyName,
            ImageUrl = x.ImageUrl
        };
    }

    public async Task CreateTestimonialAsync(CreateTestimonialDto dto)
    {
        var item = new Testimonial
        {
            ClientName = dto.ClientName,
            Comment = dto.Comment,
            CompanyName = dto.CompanyName,
            ImageUrl = dto.ImageUrl
        };

        await _repository.AddAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateTestimonialAsync(int id, UpdateTestimonialDto dto)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null)
            throw new Exception($"Testimonial with ID {id} not found");

        item.ClientName = dto.ClientName;
        item.Comment = dto.Comment;
        item.CompanyName = dto.CompanyName;
        item.ImageUrl = dto.ImageUrl;

        await _repository.UpdateAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteTestimonialAsync(int id)
    {
        await _repository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
