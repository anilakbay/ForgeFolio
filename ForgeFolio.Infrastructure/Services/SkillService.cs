using ForgeFolio.Core.DTOs.Skill;
using ForgeFolio.Core.Entities;
using ForgeFolio.Core.Interfaces;
using ForgeFolio.Core.Interfaces.Services;

namespace ForgeFolio.Infrastructure.Services;

public class SkillService : ISkillService
{
    private readonly IRepository<Skill> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public SkillService(IRepository<Skill> repository, IUnitOfWork unitOfWork)
    {
<<<<<<< HEAD
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
=======
        _repository = repository;
        _unitOfWork = unitOfWork;
>>>>>>> anildev
    }

    public async Task<IEnumerable<SkillDto>> GetAllSkillsAsync()
    {
        var skills = await _repository.GetAllAsync();
<<<<<<< HEAD
        return skills.Select(x => new SkillDto
        {
            Id = x.Id,
            Title = x.Title,
            Value = x.Value
=======
        return skills.Select(s => new SkillDto
        {
            Id = s.Id,
            Title = s.Title,
            Value = s.Value
>>>>>>> anildev
        });
    }

    public async Task<SkillDto?> GetSkillByIdAsync(int id)
    {
        var skill = await _repository.GetByIdAsync(id);
        if (skill == null) return null;

        return new SkillDto
        {
            Id = skill.Id,
            Title = skill.Title,
            Value = skill.Value
        };
    }

<<<<<<< HEAD
    public async Task CreateSkillAsync(CreateSkillDto dto)
=======
    public async Task<SkillDto> CreateSkillAsync(CreateSkillDto dto)
>>>>>>> anildev
    {
        var skill = new Skill
        {
            Title = dto.Title,
            Value = dto.Value
        };

        await _repository.AddAsync(skill);
        await _unitOfWork.SaveChangesAsync();
<<<<<<< HEAD
=======

        return new SkillDto
        {
            Id = skill.Id,
            Title = skill.Title,
            Value = skill.Value
        };
>>>>>>> anildev
    }

    public async Task UpdateSkillAsync(int id, UpdateSkillDto dto)
    {
        var skill = await _repository.GetByIdAsync(id);
<<<<<<< HEAD
        if (skill == null)
            throw new Exception($"Skill with ID {id} not found");
=======
        if (skill == null) throw new KeyNotFoundException($"Skill with ID {id} not found");
>>>>>>> anildev

        skill.Title = dto.Title;
        skill.Value = dto.Value;

        await _repository.UpdateAsync(skill);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteSkillAsync(int id)
    {
        await _repository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
