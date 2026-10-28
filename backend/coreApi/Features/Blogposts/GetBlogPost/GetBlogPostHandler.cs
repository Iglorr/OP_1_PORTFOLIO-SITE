using CoreApi.Data;
using CoreApi.Features.Blogposts.GetBlogPosts;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CoreApi.Features.Blogposts.GetBlogPost;

public static class GetBlogPostHandler
{
    public static async Task<IResult> GetBlogPostHandle(
        int id,
        PortfolioDBContext dbContext,
        CancellationToken cancellationToken)
    {
        var blogpost = await dbContext.Blogposts
            .Where(blogpost => blogpost.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (blogpost is null)
        {
            return TypedResults.NotFound();
        }

        var response = new GetBlogPostResponse(
            blogpost.Id,
            blogpost.BlogName,
            blogpost.BlogText,
            blogpost.Datumnaangemaakt,
            JsonSerializer.Deserialize<List<SourceResponse>>(
                blogpost.BronnenJson,
                new JsonSerializerOptions(JsonSerializerDefaults.Web))
                ?? new List<SourceResponse>()
        );

        return TypedResults.Ok(response);
    }
}
