namespace ForgeFolio.Core.DTOs.Testimonial;

public class TestimonialDto
{
    public int Id { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string CompanyName { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string ImageUrl { get; set; }
}

public class CreateTestimonialDto
{
    public string ClientName { get; set; } = string.Empty;
    public string CompanyName { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string ImageUrl { get; set; }
}

public class UpdateTestimonialDto
{
    public string ClientName { get; set; } = string.Empty;
    public string CompanyName { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string ImageUrl { get; set; }
}
