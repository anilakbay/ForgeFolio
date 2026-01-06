using System.ComponentModel.DataAnnotations;

namespace ForgeFolio.Core.Entities;

/// <summary>
/// Represents a feature or service offered
/// </summary>
public class Feature : BaseEntity
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
    public string Title { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "Icon cannot exceed 100 characters")]
    public string? Icon { get; set; }
}
