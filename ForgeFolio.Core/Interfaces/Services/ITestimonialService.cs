using ForgeFolio.Core.DTOs.Testimonial;

namespace ForgeFolio.Core.Interfaces.Services;

public interface ITestimonialService
{
    Task<IEnumerable<TestimonialDto>> GetAllTestimonialsAsync();
    Task<TestimonialDto?> GetTestimonialByIdAsync(int id);
    Task<TestimonialDto> CreateTestimonialAsync(CreateTestimonialDto dto);
    Task UpdateTestimonialAsync(int id, UpdateTestimonialDto dto);
    Task DeleteTestimonialAsync(int id);
}
