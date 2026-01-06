using System.ComponentModel.DataAnnotations;

namespace ForgeFolio.Core.DTOs.Portfolio;

/// <summary>
/// DTO for reading portfolio data
/// </summary>
public class PortfolioDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? SubTitle { get; set; }
    public string? ImageUrl { get; set; }
    public string? Url { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}

/// <summary>
/// DTO for creating a new portfolio item
/// </summary>
public class CreatePortfolioDto
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

/// <summary>
/// DTO for updating an existing portfolio item
/// </summary>
public class UpdatePortfolioDto
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
