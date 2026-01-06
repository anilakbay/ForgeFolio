using ForgeFolio.Core.DTOs.ToDoList;
using ForgeFolio.Core.Entities;
using ForgeFolio.Core.Interfaces;
using ForgeFolio.Core.Interfaces.Services;

namespace ForgeFolio.Infrastructure.Services;

public class ToDoListService : IToDoListService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<ToDoList> _toDoListRepository;

    public ToDoListService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _toDoListRepository = _unitOfWork.GetRepository<ToDoList>();
    }

    public async Task<List<ResultToDoListDto>> GetAllAsync()
    {
        var values = await _toDoListRepository.GetAllAsync();
        return values.Select(x => new ResultToDoListDto
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            ImageUrl = x.ImageUrl,
            Date = x.Date,
            Status = x.Status,
            CreatedAt = x.CreatedAt
        }).ToList();
    }

    public async Task<ResultToDoListDto> GetByIdAsync(int id)
    {
        var value = await _toDoListRepository.GetByIdAsync(id);
        if (value == null) return null;

        return new ResultToDoListDto
        {
            Id = value.Id,
            Title = value.Title,
            Description = value.Description,
            ImageUrl = value.ImageUrl,
            Date = value.Date,
            Status = value.Status,
            CreatedAt = value.CreatedAt
        };
    }

    public async Task CreateAsync(CreateToDoListDto createDto)
    {
        var toDoList = new ToDoList
        {
            Title = createDto.Title,
            Description = createDto.Description,
            ImageUrl = createDto.ImageUrl,
            Date = createDto.Date,
            Status = createDto.Status
        };

        await _toDoListRepository.AddAsync(toDoList);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(UpdateToDoListDto updateDto)
    {
        var value = await _toDoListRepository.GetByIdAsync(updateDto.Id);
        if (value != null)
        {
            value.Title = updateDto.Title;
            value.Description = updateDto.Description;
            value.ImageUrl = updateDto.ImageUrl;
            value.Date = updateDto.Date;
            value.Status = updateDto.Status;

            await _toDoListRepository.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var value = await _toDoListRepository.GetByIdAsync(id);
        if (value != null)
        {
            await _toDoListRepository.DeleteAsync(value.Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task ChangeStatusAsync(int id, bool status)
    {
        var value = await _toDoListRepository.GetByIdAsync(id);
        if (value != null)
        {
            value.Status = status;
            await _toDoListRepository.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
