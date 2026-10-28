namespace CoreApi.Features.Blogposts.CreateBlogPost;

public static class CreateBlogPostEndpoint
{
    public static RouteHandlerBuilder MapCreateBlogPostEndpoint(this RouteGroupBuilder routeGroupBuilder)
    {
        return routeGroupBuilder
            .MapPost("", CreateBlogPostHandler.CreateBlogPostHandle)
            .WithName("CreateBlogPost")
            .Produces<CreateBlogPostResponse>(StatusCodes.Status201Created)
            .ProducesValidationProblem();
    }
}
