namespace CoreApi.Features.Projects.GetProjects;

public sealed record class GetProjectsResponse(
    int Id,
    string Name,
    string Description,
    string Category,
    string GitHubUrl,
    DateTime Date,
    string Image,
    string AltText);
