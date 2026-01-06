using ForgeFolio.Core.DTOs.ToDoList;

namespace ForgeFolio.Core.Interfaces.Services;

public interface IToDoListService
{
    Task<List<ResultToDoListDto>> GetAllAsync();
    Task<ResultToDoListDto> GetByIdAsync(int id);
    Task CreateAsync(CreateToDoListDto createDto);
    Task UpdateAsync(UpdateToDoListDto updateDto);
    Task DeleteAsync(int id);
    Task ChangeStatusAsync(int id, bool status);
}
