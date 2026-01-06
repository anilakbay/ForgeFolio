namespace ForgeFolio.Core.DTOs.About;

public class AboutDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string SubDescription { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
}

public class UpdateAboutDto
{
    public string Title { get; set; } = string.Empty;
    public string SubDescription { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
}
