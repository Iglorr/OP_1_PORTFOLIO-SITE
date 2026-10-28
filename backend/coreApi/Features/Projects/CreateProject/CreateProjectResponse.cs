namespace CoreApi.Features.Projects.CreateProject;

public sealed record class CreateProjectResponse(
    int Id,
    string Name,
    string Description,
    string Category,
    string GitHubUrl,
    DateTime Date,
    string Image,
    string AltText);
