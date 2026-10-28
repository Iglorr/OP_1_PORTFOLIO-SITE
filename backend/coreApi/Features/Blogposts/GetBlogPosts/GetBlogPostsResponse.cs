namespace CoreApi.Features.Blogposts.GetBlogPosts;

public sealed record class GetBlogPostsResponse(
    int Id,
    string Title,
    string Text,
    DateTime Date,
    List<SourceResponse> Sources);
