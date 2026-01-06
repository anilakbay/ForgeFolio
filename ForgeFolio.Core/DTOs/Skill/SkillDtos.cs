namespace ForgeFolio.Core.DTOs.Skill;

public class SkillDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Value { get; set; }
}

public class CreateSkillDto
{
    public string Title { get; set; } = string.Empty;
    public int Value { get; set; }
}

public class UpdateSkillDto
{
    public string Title { get; set; } = string.Empty;
    public int Value { get; set; }
}
