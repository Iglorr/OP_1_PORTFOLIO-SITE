namespace CoreApi.Features.Blogposts.GetBlogPost;

public static class GetBlogPostEndpoint
{
    public static RouteHandlerBuilder MapGetBlogPostEndpoint(this RouteGroupBuilder routeGroupBuilder)
    {
        return routeGroupBuilder
            .MapGet("/{id:int}", GetBlogPostHandler.GetBlogPostHandle)
            .WithName("GetBlogPost")
            .Produces<GetBlogPostResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
    }
}
