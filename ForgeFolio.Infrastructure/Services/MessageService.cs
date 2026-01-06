using ForgeFolio.Core.Entities;
using ForgeFolio.Core.Interfaces;
using ForgeFolio.Core.Interfaces.Services;

namespace ForgeFolio.Infrastructure.Services;

/// <summary>
/// Message service implementation
/// </summary>
public class MessageService : IMessageService
{
    private readonly IRepository<Message> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public MessageService(IRepository<Message> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<IEnumerable<MessageDto>> GetAllMessagesAsync()
    {
        var messages = await _repository.GetAllAsync();
        return messages.Select(m => MapToDto(m));
    }

    public async Task<IEnumerable<MessageDto>> GetUnreadMessagesAsync()
    {
        var allMessages = await _repository.GetAllAsync();
        var unreadMessages = allMessages.Where(m => !m.IsRead);
        return unreadMessages.Select(m => MapToDto(m));
    }

    public async Task<MessageDto?> GetMessageByIdAsync(int id)
    {
        var message = await _repository.GetByIdAsync(id);
        return message == null ? null : MapToDto(message);
    }

    public async Task<MessageDto> CreateMessageAsync(CreateMessageDto dto)
    {
        var message = new Message
        {
            NameSurname = dto.NameSurname,
            Subject = dto.Subject,
            Email = dto.Email,
            MessageDetail = dto.MessageDetail,
            MessageDate = DateTime.UtcNow,
            IsRead = false
        };

        await _repository.AddAsync(message);
        await _unitOfWork.SaveChangesAsync();

        return MapToDto(message);
    }

    public async Task MarkAsReadAsync(int id)
    {
        var message = await _repository.GetByIdAsync(id);
        if (message == null)
            throw new KeyNotFoundException($"Message with ID {id} not found");

        message.IsRead = true;
        await _repository.UpdateAsync(message);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task MarkAsUnreadAsync(int id)
    {
        var message = await _repository.GetByIdAsync(id);
        if (message == null)
            throw new KeyNotFoundException($"Message with ID {id} not found");

        message.IsRead = false;
        await _repository.UpdateAsync(message);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<int> GetUnreadCountAsync()
    {
        var allMessages = await _repository.GetAllAsync();
        return allMessages.Count(m => !m.IsRead);
    }

    private static MessageDto MapToDto(Message message)
    {
        return new MessageDto
        {
            Id = message.Id,
            NameSurname = message.NameSurname,
            Subject = message.Subject,
            Email = message.Email,
            MessageDetail = message.MessageDetail,
            MessageDate = message.MessageDate,
            IsRead = message.IsRead
        };
    }
}
