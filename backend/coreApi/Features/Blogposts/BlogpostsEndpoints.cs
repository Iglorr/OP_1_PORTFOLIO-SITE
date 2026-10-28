using CoreApi.Features.Blogposts.GetBlogPosts;
using CoreApi.Features.Blogposts.GetBlogPost;
using CoreApi.Features.Blogposts.CreateBlogPost;
using CoreApi.Features.Blogposts.UpdateBlogPost;
using CoreApi.Features.Blogposts.DeleteBlogPost;

namespace CoreApi.Features.Blogposts;

public static class BlogpostsEndpoints
{
    public static RouteGroupBuilder MapAllBlogpostsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        RouteGroupBuilder group = endpoints.MapGroup("/api/blogposts").WithTags("Blogposts");

        group.MapGetBlogPostsEndpoint();
        group.MapGetBlogPostEndpoint();
        group.MapCreateBlogPostEndpoint();
        group.MapUpdateBlogPostEndpoint();
        group.MapDeleteBlogPostEndpoint();

        return group;
    }
}
