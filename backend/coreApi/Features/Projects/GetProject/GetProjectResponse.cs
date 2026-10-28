namespace CoreApi.Features.Projects.GetProject;

public sealed record class GetProjectResponse(
    int Id,
    string Name,
    string Description,
    string Category,
    string GitHubUrl,
    DateTime Date,
    string Image,
    string AltText);
