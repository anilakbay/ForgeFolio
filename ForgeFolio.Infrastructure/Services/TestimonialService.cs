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
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TestimonialDto>> GetAllTestimonialsAsync()
    {
        var testimonials = await _repository.GetAllAsync();
        return testimonials.Select(t => new TestimonialDto
        {
            Id = t.Id,
            ClientName = t.ClientName,
            CompanyName = t.CompanyName,
            Comment = t.Comment,
            ImageUrl = t.ImageUrl
        });
    }

    public async Task<TestimonialDto?> GetTestimonialByIdAsync(int id)
    {
        var testimonial = await _repository.GetByIdAsync(id);
        if (testimonial == null) return null;

        return new TestimonialDto
        {
            Id = testimonial.Id,
            ClientName = testimonial.ClientName,
            CompanyName = testimonial.CompanyName,
            Comment = testimonial.Comment,
            ImageUrl = testimonial.ImageUrl
        };
    }

    public async Task<TestimonialDto> CreateTestimonialAsync(CreateTestimonialDto dto)
    {
        var testimonial = new Testimonial
        {
            ClientName = dto.ClientName,
            CompanyName = dto.CompanyName,
            Comment = dto.Comment,
            ImageUrl = dto.ImageUrl
        };

        await _repository.AddAsync(testimonial);
        await _unitOfWork.SaveChangesAsync();

        return new TestimonialDto
        {
            Id = testimonial.Id,
            ClientName = testimonial.ClientName,
            CompanyName = testimonial.CompanyName,
            Comment = testimonial.Comment,
            ImageUrl = testimonial.ImageUrl
        };
    }

    public async Task UpdateTestimonialAsync(int id, UpdateTestimonialDto dto)
    {
        var testimonial = await _repository.GetByIdAsync(id);
        if (testimonial == null) throw new KeyNotFoundException($"Testimonial with ID {id} not found");

        testimonial.ClientName = dto.ClientName;
        testimonial.CompanyName = dto.CompanyName;
        testimonial.Comment = dto.Comment;
        testimonial.ImageUrl = dto.ImageUrl;

        await _repository.UpdateAsync(testimonial);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteTestimonialAsync(int id)
    {
        await _repository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
