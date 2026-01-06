using System.ComponentModel.DataAnnotations;

namespace ForgeFolio.Core.Entities;

/// <summary>
/// Represents a portfolio project
/// </summary>
public class Portfolio : BaseEntity
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
    public string Title { get; set; } = string.Empty;

    [StringLength(300, ErrorMessage = "Subtitle cannot exceed 300 characters")]
    public string? SubTitle { get; set; }

    [StringLength(500, ErrorMessage = "Image URL cannot exceed 500 characters")]
    [Url(ErrorMessage = "Please provide a valid URL")]
    public string? ImageUrl { get; set; }

    [StringLength(500, ErrorMessage = "URL cannot exceed 500 characters")]
    [Url(ErrorMessage = "Please provide a valid URL")]
    public string? Url { get; set; }

    [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters")]
    public string? Description { get; set; }
}
