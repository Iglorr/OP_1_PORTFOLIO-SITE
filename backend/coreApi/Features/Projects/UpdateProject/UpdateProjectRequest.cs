using System.ComponentModel.DataAnnotations;

namespace CoreApi.Features.Projects.UpdateProject;

public sealed record class UpdateProjectRequest
{
    [Required(ErrorMessage = "Vul een projectnaam in.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vul een beschrijving in.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vul een categorie in.")]
    public string Category { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vul een GitHub-adres in.")]
    [Url(ErrorMessage = "Vul een geldig webadres in.")]
    public string GitHubUrl { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;
    public string AltText { get; set; } = string.Empty;
}
