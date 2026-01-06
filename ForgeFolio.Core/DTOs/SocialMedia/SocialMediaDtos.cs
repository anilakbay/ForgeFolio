
namespace ForgeFolio.Core.DTOs.SocialMedia;

public class SocialMediaDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Url { get; set; }
    public string? Icon { get; set; }
}

public class CreateSocialMediaDto
{
    public string Title { get; set; } = string.Empty;
    public string? Url { get; set; }
    public string? Icon { get; set; }
}

public class UpdateSocialMediaDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Url { get; set; }
    public string? Icon { get; set; }
}
