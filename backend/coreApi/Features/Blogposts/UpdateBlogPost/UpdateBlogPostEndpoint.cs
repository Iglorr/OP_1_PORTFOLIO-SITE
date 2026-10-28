namespace CoreApi.Features.Blogposts.UpdateBlogPost;

public static class UpdateBlogPostEndpoint
{
    public static RouteHandlerBuilder MapUpdateBlogPostEndpoint(this RouteGroupBuilder routeGroupBuilder)
    {
        return routeGroupBuilder
            .MapPut("/{id:int}", UpdateBlogPostHandler.UpdateBlogPostHandle)
            .WithName("UpdateBlogPost")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesValidationProblem();
    }
}
