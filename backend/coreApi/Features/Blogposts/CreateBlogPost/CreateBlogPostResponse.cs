namespace CoreApi.Features.Blogposts.CreateBlogPost;

public sealed record class CreateBlogPostResponse(
    int Id,
    string Title,
    string Text,
    DateTime Date);