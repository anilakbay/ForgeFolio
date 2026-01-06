using System.ComponentModel.DataAnnotations;

namespace ForgeFolio.Core.Entities;

/// <summary>
/// Represents a client testimonial
/// </summary>
public class Testimonial : BaseEntity
{
    [Required(ErrorMessage = "Client name is required")]
    [StringLength(100, ErrorMessage = "Client name cannot exceed 100 characters")]
    public string ClientName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Comment is required")]
    [StringLength(1000, ErrorMessage = "Comment cannot exceed 1000 characters")]
    public string Comment { get; set; } = string.Empty;

    [StringLength(200, ErrorMessage = "Company name cannot exceed 200 characters")]
    public string? CompanyName { get; set; }

    [StringLength(500, ErrorMessage = "Image URL cannot exceed 500 characters")]
    public string? ImageUrl { get; set; }
}
