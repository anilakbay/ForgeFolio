using System.ComponentModel.DataAnnotations;

namespace ForgeFolio.Core.Entities;

/// <summary>
/// Represents a todo list item
/// </summary>
public class ToDoList : BaseEntity
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
    public string Title { get; set; } = string.Empty;

    [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
    public string? Description { get; set; }

    [StringLength(500, ErrorMessage = "Image URL cannot exceed 500 characters")]
    public string? ImageUrl { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;

    public bool Status { get; set; } = false;
}
