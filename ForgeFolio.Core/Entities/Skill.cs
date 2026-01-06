using System.ComponentModel.DataAnnotations;

namespace ForgeFolio.Core.Entities;

/// <summary>
/// Represents a skill and proficiency level
/// </summary>
public class Skill : BaseEntity
{
    [Required(ErrorMessage = "Skill title is required")]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
    public string Title { get; set; } = string.Empty;

    [Range(0, 100, ErrorMessage = "Value must be between 0 and 100")]
    public int Value { get; set; } = 0;
}
