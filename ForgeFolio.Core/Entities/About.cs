using System.ComponentModel.DataAnnotations;

namespace ForgeFolio.Core.Entities;

/// <summary>
/// Represents information about the portfolio owner
/// </summary>
public class About : BaseEntity
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Sub description is required")]
    [StringLength(500, ErrorMessage = "Sub description cannot exceed 500 characters")]
    public string SubDescription { get; set; } = string.Empty;

    [Required(ErrorMessage = "Details are required")]
    [StringLength(2000, ErrorMessage = "Details cannot exceed 2000 characters")]
    public string Details { get; set; } = string.Empty;
}
