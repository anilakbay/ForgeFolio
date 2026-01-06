using System.ComponentModel.DataAnnotations;

namespace ForgeFolio.Core.DTOs.Message;

/// <summary>
/// DTO for reading message data
/// </summary>
public class MessageDto
{
    public int Id { get; set; }
    public string NameSurname { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string MessageDetail { get; set; } = string.Empty;
    public DateTime MessageDate { get; set; }
    public bool IsRead { get; set; }
}

/// <summary>
/// DTO for creating a new message
/// </summary>
public class CreateMessageDto
{
    [Required(ErrorMessage = "Name and surname are required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string NameSurname { get; set; } = string.Empty;

    [Required(ErrorMessage = "Subject is required")]
    [StringLength(200, ErrorMessage = "Subject cannot exceed 200 characters")]
    public string Subject { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please provide a valid email address")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Message is required")]
    [StringLength(2000, ErrorMessage = "Message cannot exceed 2000 characters")]
    public string MessageDetail { get; set; } = string.Empty;
}
