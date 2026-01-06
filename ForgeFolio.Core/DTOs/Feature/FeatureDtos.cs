
namespace ForgeFolio.Core.DTOs.Feature;

public class FeatureDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Header { get; set; }
    public string? NameSurname { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
}

public class CreateFeatureDto
{
    public string Title { get; set; } = string.Empty;
    public string? Header { get; set; }
    public string? NameSurname { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
}

public class UpdateFeatureDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Header { get; set; }
    public string? NameSurname { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
}
