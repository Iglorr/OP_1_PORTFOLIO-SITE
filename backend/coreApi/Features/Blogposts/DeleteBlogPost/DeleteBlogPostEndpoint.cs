namespace CoreApi.Features.Blogposts.DeleteBlogPost;

public static class DeleteBlogPostEndpoint
{
    public static RouteHandlerBuilder MapDeleteBlogPostEndpoint(this RouteGroupBuilder routeGroupBuilder)
    {
        return routeGroupBuilder
            .MapDelete("/{id:int}", DeleteBlogPostHandler.DeleteBlogPostHandle)
            .WithName("DeleteBlogPost")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
    }
}
