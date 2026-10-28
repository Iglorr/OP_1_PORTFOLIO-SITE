using System.ComponentModel.DataAnnotations;

namespace CoreApi.Features.Blogposts.CreateBlogPost;

public sealed record class SourceRequest
{
    [Required(ErrorMessage = "Vul de titel van de bron in.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vul het webadres van de bron in.")]
    [Url(ErrorMessage = "Vul een geldig webadres in.")]
    public string Url { get; set; } = string.Empty;
}
