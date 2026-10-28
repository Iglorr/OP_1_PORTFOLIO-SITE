using CoreApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CoreApi.Features.Blogposts.UpdateBlogPost;

public static class UpdateBlogPostHandler
{
    public static async Task<IResult> UpdateBlogPostHandle(
        int id, UpdateBlogPostRequest request,
        PortfolioDBContext dbContext, CancellationToken cancellationToken)
    {
        var blogpost = await dbContext.Blogposts
            .FirstOrDefaultAsync(blogpost => blogpost.Id == id, cancellationToken);

        if (blogpost is null)
        {
            return TypedResults.NotFound();
        }

        blogpost.BlogName = request.Title;
        blogpost.BlogText = request.Text;
        blogpost.BronnenJson = JsonSerializer.Serialize(
            request.Sources, new JsonSerializerOptions(JsonSerializerDefaults.Web));

        await dbContext.SaveChangesAsync(cancellationToken);

        return TypedResults.NoContent();
    }
}
