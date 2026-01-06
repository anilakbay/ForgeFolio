using System.ComponentModel.DataAnnotations;

namespace ForgeFolio.Core.Entities;

/// <summary>
/// Represents social media platform information
/// </summary>
public class SocialMedia : BaseEntity
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
    public string Title { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "URL cannot exceed 500 characters")]
    [Url(ErrorMessage = "Please provide a valid URL")]
    public string? Url { get; set; }

    [StringLength(50, ErrorMessage = "Icon cannot exceed 50 characters")]
    public string? Icon { get; set; }
}
