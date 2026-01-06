using ForgeFolio.Core.DTOs.Message;

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
