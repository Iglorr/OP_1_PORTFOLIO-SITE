using CoreApi.Data;
using CoreApi.Domain;

namespace CoreApi.Features.Projects.CreateProject;

public static class CreateProjectHandler
{
    public static async Task<IResult> CreateProjectHandle(
        CreateProjectRequest request, PortfolioDBContext dbContext, CancellationToken cancellationToken)
    {
        var project = new Project
        {
            ProjectName = request.Name,
            ProjectText = request.Description,
            ProjectCategory = request.Category,
            GitHubUrl = request.GitHubUrl,
            Date = DateTime.UtcNow,
            ProjectImage = request.Image,
            ProjectAltText = request.AltText
        };

        dbContext.Projects.Add(project);
        await dbContext.SaveChangesAsync(cancellationToken);

        var response = new CreateProjectResponse(
            project.Id, project.ProjectName, project.ProjectText,
                project.ProjectCategory, project.GitHubUrl, project.Date,
                project.ProjectImage, project.ProjectAltText);

        return TypedResults.CreatedAtRoute(response, "GetProject", new { id = project.Id });
    }
}
