using ForgeFolio.Core.DTOs.Skill;

namespace ForgeFolio.Core.Interfaces.Services;

public interface ISkillService
{
    Task<IEnumerable<SkillDto>> GetAllSkillsAsync();
    Task<SkillDto?> GetSkillByIdAsync(int id);
    Task CreateSkillAsync(CreateSkillDto dto);
    Task UpdateSkillAsync(int id, UpdateSkillDto dto);
    Task DeleteSkillAsync(int id);
}
