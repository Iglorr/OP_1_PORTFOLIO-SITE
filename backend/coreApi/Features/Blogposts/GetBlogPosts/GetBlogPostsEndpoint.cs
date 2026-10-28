namespace CoreApi.Features.Blogposts.GetBlogPosts;

public static class GetBlogPostsEndpoint
{
    public static RouteHandlerBuilder MapGetBlogPostsEndpoint(this RouteGroupBuilder routeGroupBuilder)
    {
        return routeGroupBuilder
            .MapGet("", GetBlogPostsHandler.GetBlogPostsHandle)
            .WithName("GetBlogPosts")
            .Produces<List<GetBlogPostsResponse>>(StatusCodes.Status200OK);
    }
}
