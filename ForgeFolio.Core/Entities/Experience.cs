using System.ComponentModel.DataAnnotations;

namespace ForgeFolio.Core.Entities;

/// <summary>
/// Represents work experience information
/// </summary>
public class Experience : BaseEntity
{
    [Required(ErrorMessage = "Head is required")]
    [StringLength(100, ErrorMessage = "Head cannot exceed 100 characters")]
    public string Head { get; set; } = string.Empty;

    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Date is required")]
    [StringLength(100, ErrorMessage = "Date cannot exceed 100 characters")]
    public string Date { get; set; } = string.Empty;

    [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
    public string? Description { get; set; }
}
