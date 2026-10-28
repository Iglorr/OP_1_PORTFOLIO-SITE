using System.ComponentModel.DataAnnotations;
using CoreApi.Features.Blogposts.CreateBlogPost;

namespace CoreApi.Features.Blogposts.UpdateBlogPost;

public sealed record class UpdateBlogPostRequest
{
    [Required(ErrorMessage = "Vul een titel in.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vul de blogtekst in.")]
    public string Text { get; set; } = string.Empty;

    [Required(ErrorMessage = "Gebruik een lege lijst als er geen bronnen zijn.")]
    public List<SourceRequest> Sources { get; set; } = new List<SourceRequest>();
}
