using CoreApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CoreApi.Features.Blogposts.GetBlogPosts;

public static class GetBlogPostsHandler
{
    public static async Task<IResult> GetBlogPostsHandle(
        PortfolioDBContext dbContext, CancellationToken cancellationToken)
    {
        var blogposts = await dbContext.Blogposts
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var responses = blogposts.Select(blogpost => new GetBlogPostsResponse(
            blogpost.Id,
            blogpost.BlogName,
            blogpost.BlogText,
            blogpost.Datumnaangemaakt,
            JsonSerializer.Deserialize<List<SourceResponse>>(
                blogpost.BronnenJson,
                new JsonSerializerOptions(JsonSerializerDefaults.Web)) ?? new List<SourceResponse>()
        )).ToList();

        return TypedResults.Ok(responses);
    }
}
