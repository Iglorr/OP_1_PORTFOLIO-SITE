using CoreApi.Features.Blogposts.GetBlogPosts;

namespace CoreApi.Features.Blogposts.GetBlogPost;

public sealed record class GetBlogPostResponse(
    int Id,
    string Title,
    string Text,
    DateTime Date,
    List<SourceResponse> Sources);