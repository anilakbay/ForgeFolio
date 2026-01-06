namespace ForgeFolio.Core.Interfaces.Services;

/// <summary>
/// Service interface for Message operations  
/// </summary>
public interface IMessageService
{
    Task<IEnumerable<MessageDto>> GetAllMessagesAsync();
    Task<IEnumerable<MessageDto>> GetUnreadMessagesAsync();
    Task<MessageDto?> GetMessageByIdAsync(int id);
    Task<MessageDto> CreateMessageAsync(CreateMessageDto dto);
    Task MarkAsReadAsync(int id);
    Task MarkAsUnreadAsync(int id);
    Task<int> GetUnreadCountAsync();
}

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

public class CreateMessageDto
{
    public string NameSurname { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string MessageDetail { get; set; } = string.Empty;
}
