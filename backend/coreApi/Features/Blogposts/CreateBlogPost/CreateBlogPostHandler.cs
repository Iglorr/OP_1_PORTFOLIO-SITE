using CoreApi.Data;
using CoreApi.Domain;
using System.Text.Json;

namespace CoreApi.Features.Blogposts.CreateBlogPost;

public static class CreateBlogPostHandler
{
    public static async Task<IResult> CreateBlogPostHandle(
        CreateBlogPostRequest request,
        PortfolioDBContext dbContext,
        CancellationToken cancellationToken)
    {
        var blogpost = new Blogpost
        {
            BlogName = request.Title,
            BlogText = request.Text,
            Datumnaangemaakt = DateTime.UtcNow,
            BronnenJson = JsonSerializer.Serialize(
                request.Sources,
                new JsonSerializerOptions(JsonSerializerDefaults.Web))
        };

        dbContext.Blogposts.Add(blogpost);

        await dbContext.SaveChangesAsync(cancellationToken);

        var response = new CreateBlogPostResponse(
            blogpost.Id,
            blogpost.BlogName,
            blogpost.BlogText,
            blogpost.Datumnaangemaakt);

        return TypedResults.CreatedAtRoute(
            response,
            "GetBlogPost",
            new { id = blogpost.Id });
    }
}
