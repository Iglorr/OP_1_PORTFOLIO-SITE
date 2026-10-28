using CoreApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreApi.Features.Blogposts.DeleteBlogPost;

public static class DeleteBlogPostHandler
{
    public static async Task<IResult> DeleteBlogPostHandle(
        int id, PortfolioDBContext dbContext, CancellationToken cancellationToken)
    {
        var blogpost = await dbContext.Blogposts
            .FirstOrDefaultAsync(blogpost => blogpost.Id == id, cancellationToken);

        if (blogpost is null)
        {
            return TypedResults.NotFound();
        }

        dbContext.Blogposts.Remove(blogpost);
        await dbContext.SaveChangesAsync(cancellationToken);

        return TypedResults.NoContent();
    }
}
